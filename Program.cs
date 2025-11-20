using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using cms_webapi.Data;
using cms_webapi.Interfaces;
using cms_webapi.Repositories;
using cms_webapi.Mappings;
using cms_webapi.Services;
using cms_webapi.Hubs;
using cms_webapi.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add HttpContextAccessor for auditing in repositories
builder.Services.AddHttpContextAccessor();

// SignalR Configuration
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

// Configure Entity Framework
builder.Services.AddDbContext<CmsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure ERP Entity Framework (ErpConnection string kullanır)
builder.Services.AddDbContext<ErpCmsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ErpConnection")));

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register repositories and Unit of Work
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register JWT Service
builder.Services.AddScoped<IJwtService, JwtService>();

// Register Localization Service
builder.Services.AddScoped<ILocalizationService, LocalizationService>();

// Register Business Services
builder.Services.AddScoped<IAuthService, AuthService>();
// Removed invalid UserService registration (no IUserService/UserService implementation)
builder.Services.AddScoped<IErpService, ErpService>();
builder.Services.AddScoped<ITitleService, TitleService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerTypeService, CustomerTypeService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IProductPricingService, ProductPricingService>();
builder.Services.AddScoped<IProductPricingGroupByService, ProductPricingGroupByService>();
builder.Services.AddScoped<IUserDiscountLimitService, UserDiscountLimitService>();
builder.Services.AddScoped<IPaymentTypeService, PaymentTypeService>();
builder.Services.AddScoped<IShippingAddressService, ShippingAddressService>();
builder.Services.AddScoped<IQuotationService, QuotationService>();
builder.Services.AddScoped<IQuotationLineService, QuotationLineService>();
builder.Services.AddScoped<IQuotationApprovalService, QuotationApprovalService>();
builder.Services.AddScoped<IQuotationLineApprovalService, QuotationLineApprovalService>();
builder.Services.AddScoped<IApprovalWorkflowService, ApprovalWorkflowService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserSessionService, UserSessionService>();
builder.Services.AddScoped<IQuotationDocumentTypeService, QuotationDocumentTypeService>();
builder.Services.AddScoped<IUserAuthorityService, UserAuthorityService>();
builder.Services.AddScoped<IDocumentNumberService, DocumentNumberService>();

// Configure Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR")
    };
    
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    
    // Add custom request culture provider for x-language header
    options.RequestCultureProviders.Insert(0, new CustomHeaderRequestCultureProvider());
});

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"] ?? "YourSuperSecretKeyThatIsAtLeast32CharactersLong!";
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"] ?? "CmsWebApi",
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"] ?? "CmsWebApiUsers",
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

    // JWT Events for SignalR and session validation
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            // Support tokens sent via query for SignalR
            var accessToken = context.Request.Query["access_token"]; 
            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/api/authHub"))
            {
                context.Token = accessToken;
                return Task.CompletedTask;
            }

            // Accept tokens without "Bearer " prefix and from alternative header
            var authorization = context.Request.Headers["Authorization"].FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(authorization))
            {
                const string bearerPrefix = "Bearer ";
                if (authorization.StartsWith(bearerPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    context.Token = authorization.Substring(bearerPrefix.Length).Trim();
                }
                else if (authorization.Count(c => c == '.') == 2)
                {
                    context.Token = authorization.Trim();
                }
            }
            else
            {
                var altToken = context.Request.Headers["x-access-token"].FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(altToken))
                {
                    context.Token = altToken.Trim();
                }
            }

            return Task.CompletedTask;
        },
        OnTokenValidated = async context =>
        {
            // Ensure user has an active session
            var db = context.HttpContext.RequestServices.GetRequiredService<CmsDbContext>();
            var userId = context.Principal?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                context.Fail("Token geçersiz: eksik kullanıcı ID");
                return;
            }

            var session = await db.Set<cms_webapi.Models.UserSession>()
                .FirstOrDefaultAsync(s => s.UserId.ToString() == userId && s.RevokedAt == null);

            if (session == null)
            {
                context.Fail("Token geçersiz veya oturum kapandı");
            }
        }
    };
});

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "CMS Web API",
        Version = "v1",
        Description = "A comprehensive Content Management System Web API with JWT Authentication",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "CMS API Team",
            Email = "support@cmsapi.com"
        }
    });
    
    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    
    // Add Language Header to Swagger
    c.AddSecurityDefinition("Language", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Language header for localization. Use 'tr' for Turkish or 'en' for English. Example: \"x-language: tr\"",
        Name = "x-language",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "ApiKey"
    });
    
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        },
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Language"
                }
            },
            new string[] {}
        }
    });
    
    // Include XML comments if available
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
    // CORS policy for SignalR with credentials
    options.AddPolicy("SignalRCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS Web API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

// Add Request Localization Middleware
app.UseRequestLocalization();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Map SignalR hub (align with frontend base URL: /api)
app.MapHub<AuthHub>("/api/authHub").RequireCors("SignalRCorsPolicy");

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CmsDbContext>();
    try
    {
        context.Database.EnsureCreated();
        Console.WriteLine("Database created successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error creating database: {ex.Message}");
    }
}

app.Run();
