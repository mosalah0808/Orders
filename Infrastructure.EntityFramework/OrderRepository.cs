using Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementations
{
    public class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        private readonly DatabaseContext _db;
        public OrderRepository(DatabaseContext db) : base(db)
        {
            _db = db;
        }

        public  new async Task<Order?> GetById(Guid id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return await _db.Orders.Include(o => o.Lines).FirstOrDefaultAsync(s => s.Id.ToString() == id.ToString());
        }
    }
}
