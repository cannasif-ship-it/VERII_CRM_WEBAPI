using Microsoft.EntityFrameworkCore;
using depoWebAPI.Models;
using cms_webapi.Data;
using cms_webapi.Interfaces;
using cms_webapi.DTOs;
using cms_webapi.UnitOfWork;

namespace cms_webapi.Services
{
    public class ErpService : IErpService
    {
        private readonly ErpCmsDbContext _erpContext;
        private readonly ILogger<ErpService> _logger;
        private readonly ILocalizationService _localizationService;

        public ErpService(ErpCmsDbContext erpContext, ILogger<ErpService> logger, ILocalizationService localizationService)
        {
            _erpContext = erpContext;
            _logger = logger;
            _localizationService = localizationService;
        }

        // VW (View) Operations - Sadece GET işlemleri
        public async Task<ApiResponse<IEnumerable<RII_VW_CARI>>> GetAllCariAsync()
        {
            try
            {
                var cariList = await _erpContext.RII_VW_CARI.ToListAsync();

                return ApiResponse<IEnumerable<RII_VW_CARI>>.SuccessResult(cariList, _localizationService.GetLocalizedString("CariRecordsRetrieved"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all Cari records");
                return ApiResponse<IEnumerable<RII_VW_CARI>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<IEnumerable<RII_VW_DEPO>>> GetAllDepoAsync()
        {
            try
            {
                var depoList = await _erpContext.RII_VW_DEPO.ToListAsync();

                return ApiResponse<IEnumerable<RII_VW_DEPO>>.SuccessResult(depoList, _localizationService.GetLocalizedString("DepoRecordsRetrieved"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all Depo records");
                return ApiResponse<IEnumerable<RII_VW_DEPO>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<IEnumerable<RII_VW_STOK>>> GetAllStokAsync()
        {
            try
            {
                var stokList = await _erpContext.RII_VW_STOK.ToListAsync();

                return ApiResponse<IEnumerable<RII_VW_STOK>>.SuccessResult(stokList, _localizationService.GetLocalizedString("StokRecordsRetrieved"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all Stok records");
                return ApiResponse<IEnumerable<RII_VW_STOK>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<IEnumerable<RII_VW_PROJE>>> GetAllProjeAsync()
        {
            try
            {
                var projeList = await _erpContext.RII_VW_PROJE.ToListAsync();

                return ApiResponse<IEnumerable<RII_VW_PROJE>>.SuccessResult(projeList, _localizationService.GetLocalizedString("ProjeRecordsRetrieved"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all Proje records");
                return ApiResponse<IEnumerable<RII_VW_PROJE>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        // FN (Function) Operations - Parametreli sorgular
        public async Task<ApiResponse<IEnumerable<RII_FN_ONHANDQUANTITY>>> GetOnHandQuantityWithSerialAsync(
            ErpCmsDbContext context, 
            int? depoKodu = null, 
            string? stokKodu = null, 
            string? seriNo = null, 
            string? projeKodu = null)
        {
            try
            {

                var query = context.RII_FN_ONHANDQUANTITY.AsQueryable();

                if (depoKodu.HasValue)
                    query = query.Where(x => x.DEPO_KODU == depoKodu.Value);

                if (!string.IsNullOrEmpty(stokKodu))
                    query = query.Where(x => x.STOK_KODU == stokKodu);

                if (!string.IsNullOrEmpty(seriNo))
                    query = query.Where(x => x.SERI_NO == seriNo);

                if (!string.IsNullOrEmpty(projeKodu))
                    query = query.Where(x => x.PROJE_KODU == projeKodu);

                var onHandList = await query.ToListAsync();

                return ApiResponse<IEnumerable<RII_FN_ONHANDQUANTITY>>.SuccessResult(onHandList, _localizationService.GetLocalizedString("OnHandQuantityRetrieved"));
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<RII_FN_ONHANDQUANTITY>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ApiResponse<IEnumerable<ERP_GetProductPricing>>> GetProductPricingAsync(ErpCmsDbContext context, string stokKodu)
        {
            try
            {
                var result = await context.ERP_GetProductPricing
                    .FromSqlInterpolated($"SELECT * FROM dbo.GetProductPricing({stokKodu})")
                    .ToListAsync();
                return ApiResponse<IEnumerable<ERP_GetProductPricing>>.SuccessResult(result, _localizationService.GetLocalizedString("ProductPricingRetrieved"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting product pricing");
                return ApiResponse<IEnumerable<ERP_GetProductPricing>>.ErrorResult(_localizationService.GetLocalizedString("InternalServerError"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        // Health Check
        public async Task<ApiResponse<object>> HealthCheckAsync()
        {
            try
            {
                // ERP veritabanı bağlantısını test et
                await _erpContext.Database.CanConnectAsync();

                return ApiResponse<object>.SuccessResult(new { Status = "Healthy", Timestamp = DateTime.UtcNow }, _localizationService.GetLocalizedString("ErpConnectionSuccessful"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERP Health check failed");
                return ApiResponse<object>.ErrorResult(_localizationService.GetLocalizedString("ErpConnectionFailed"), ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
    }
}
