using BartenderApp.DataAccess.Data;
using BartenderApp.DataAccess.Repository.IRepository;
using BartenderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BartenderApp.DataAccess.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Order order)
        {
            var objFromDb = _db.Orders.FirstOrDefault(s => s.Id == order.Id);
            if (objFromDb != null)
            {
                objFromDb.CocktailName = order.CocktailName;
                objFromDb.IsReady = order.IsReady;

                _db.SaveChanges();
            }

        }
    }
}
