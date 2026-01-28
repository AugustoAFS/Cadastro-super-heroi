using Domain.Entities.Base;

namespace Domain.Interfaces.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T?> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);
    }
}