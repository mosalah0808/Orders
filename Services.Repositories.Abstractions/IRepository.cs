using Entities;

namespace Services.Repositories.Abstractions
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> AddAsync(TEntity item);
        Task<TEntity?> GetById(TKey id);
        TEntity Update(TEntity item);
        void DeleteById(TKey id);
        void SaveChanges();
    }
}