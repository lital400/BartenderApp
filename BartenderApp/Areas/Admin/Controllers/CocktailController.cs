﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BartenderApp.DataAccess.Data;
using BartenderApp.Models;
using BartenderApp.DataAccess.Repository.IRepository;

namespace BartenderApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CocktailController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public CocktailController(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Cocktail
        public async Task<IActionResult> Index()
        {
            return View(await _db.Cocktails.ToListAsync());
        }


        public IActionResult Insert(int id)
        {
            Cocktail cocktail = new Cocktail();
            cocktail = _unitOfWork.Cocktail.Get(id);

            Order order = new Order();
            order.CocktailName = cocktail.Name;
            order.IsReady = false;

            _unitOfWork.Order.Add(order);
            _unitOfWork.Save();
            return View("Confirm");

        }


        // GET: Admin/Cocktail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktail = await _db.Cocktails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail);
        }

        // GET: Admin/Cocktail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cocktail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl")] Cocktail cocktail)
        {
            if (ModelState.IsValid)
            {
                _db.Add(cocktail);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cocktail);
        }


        // GET: Admin/Cocktail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktail = await _db.Cocktails.FindAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }
            return View(cocktail);
        }

        // POST: Admin/Cocktail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl")] Cocktail cocktail)
        {
            if (id != cocktail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(cocktail);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocktailExists(cocktail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cocktail);
        }

        // GET: Admin/Cocktail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktail = await _db.Cocktails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail);
        }

        // POST: Admin/Cocktail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cocktail = await _db.Cocktails.FindAsync(id);
            _db.Cocktails.Remove(cocktail);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocktailExists(int id)
        {
            return _db.Cocktails.Any(e => e.Id == id);
        }
    }
}
