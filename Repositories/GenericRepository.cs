using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using cms_webapi.Data;
using cms_webapi.Interfaces;
using cms_webapi.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace cms_webapi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly CmsDbContext _context;
        protected readonly DbSet<T> _dbSet;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GenericRepository(CmsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _httpContextAccessor = httpContextAccessor;
        }

        private long? GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var idClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? user?.FindFirst("UserId")?.Value;
            return long.TryParse(idClaim, out var userId) ? userId : null;
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Where(expression)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Where(expression)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = GetCurrentUserId();
            entity.IsDeleted = false;
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = GetCurrentUserId();
            _dbSet.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task SoftDeleteAsync(long id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.UtcNow;
                entity.DeletedBy = GetCurrentUserId();
                _dbSet.Update(entity);
            }
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync(e => !e.IsDeleted);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(e => !e.IsDeleted).CountAsync(expression);
        }

        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> filter)
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .Where(filter)
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
