using System.Linq.Expressions;
using cms_webapi.Models;

namespace cms_webapi.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(long id);
        Task SoftDeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> filter);
    }
}
