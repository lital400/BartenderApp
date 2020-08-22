using BartenderApp.DataAccess.Data;
using BartenderApp.DataAccess.Repository.IRepository;
using BartenderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BartenderApp.DataAccess.Repository
{
    public class CocktailRepository : Repository<Cocktail>, ICocktailRepository
    {
        private readonly ApplicationDbContext _db;

        public CocktailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cocktail cocktail)
        {
            var objFromDb = _db.Cocktails.FirstOrDefault(s => s.Id == cocktail.Id);
            if (objFromDb != null)
            {
                if (cocktail.ImageUrl != null)
                {
                    objFromDb.ImageUrl = cocktail.ImageUrl;
                }
                
                objFromDb.Name = cocktail.Name;
                objFromDb.Description = cocktail.Description;
                objFromDb.Price = cocktail.Price;

                _db.SaveChanges();
            }

        }
    }
}
