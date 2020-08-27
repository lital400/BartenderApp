using BartenderApp.DataAccess.Data;
using BartenderApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BartenderApp.DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception) {}

            if (_db.Cocktails.Any()) return;

            _db.Cocktails.Add(
                new Cocktail() { Name = "Moscow mule", Description = "Vodka, ginger beer, lime juice, crushed ice", Price = 12, ImageUrl = "/images/cocktails/MoscowMule.jpg" });
            _db.Cocktails.Add(
                new Cocktail() { Name = "Mojito", Description = "Rum, sugar, lime juice, soda water, mint", Price = 13, ImageUrl = "/images/cocktails/Mojito.jpg" });
            _db.Cocktails.Add(
                new Cocktail() { Name = "Sangria", Description = "Red Wine, brandi, orange juice, apple, cinnamon", Price = 14, ImageUrl = "/images/cocktails/Sangria.jpg" });
            _db.Cocktails.Add(
                new Cocktail() { Name = "Old Fashioned", Description = "Bitters, sugar, whiskey, citrus rind, cocktail cherry", Price = 15, ImageUrl = "/images/cocktails/OldFashioned.jpg" });

            _db.SaveChanges();
        }
    }
}
