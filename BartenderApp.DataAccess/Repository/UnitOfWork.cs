using BartenderApp.DataAccess.Data;
using BartenderApp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BartenderApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Cocktail = new CocktailRepository(_db);
            Order = new OrderRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ICocktailRepository Cocktail { get; private set; }
        public IOrderRepository Order { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
