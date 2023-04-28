using Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;


namespace Infrastructure.Repositories.Implementations
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly DatabaseContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DatabaseContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity item)
        {
            var result = await _dbSet.AddAsync(item);
            return result.Entity;
        }

        public void DeleteById(TKey id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            var targetItem = _dbSet.FirstOrDefault(s => s.Id.ToString() == id.ToString());
            if (targetItem != null)
            {
                _dbSet.Remove(targetItem);
            }
        }

        public async Task<TEntity?> GetById(TKey id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return await _dbSet.FirstOrDefaultAsync(s => s.Id.ToString() == id.ToString());
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public TEntity Update(TEntity item)
        {
            var result = _dbSet.Update(item);
            _db.SaveChanges();
            return result.Entity;
        }
    }
}
