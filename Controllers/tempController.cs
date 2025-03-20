using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairSalon.Data;
using HairSalon.Models;
using Microsoft.AspNetCore.Authorization;

namespace HairSalon.Controllers
{
    [Authorize]
    public class tempController : Controller
    {
        private readonly HairDbContext _context;

        public tempController(HairDbContext context)
        {
            _context = context;
        }

        // GET: temp
        public async Task<IActionResult> Index()
        {
              return _context.HairSalons != null ? 
                          View(await _context.HairSalons.ToListAsync()) :
                          Problem("Entity set 'HairDbContext.HairSalons'  is null.");
        }

        // GET: temp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HairSalons == null)
            {
                return NotFound();
            }

            var hairSalonData = await _context.HairSalons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairSalonData == null)
            {
                return NotFound();
            }

            return View(hairSalonData);
        }

        // GET: temp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: temp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password")] HairSalonData hairSalonData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hairSalonData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hairSalonData);
        }

        // GET: temp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HairSalons == null)
            {
                return NotFound();
            }

            var hairSalonData = await _context.HairSalons.FindAsync(id);
            if (hairSalonData == null)
            {
                return NotFound();
            }
            return View(hairSalonData);
        }

        // POST: temp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Password")] HairSalonData hairSalonData)
        {
            if (id != hairSalonData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hairSalonData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HairSalonDataExists(hairSalonData.Id))
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
            return View(hairSalonData);
        }

        // GET: temp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HairSalons == null)
            {
                return NotFound();
            }

            var hairSalonData = await _context.HairSalons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairSalonData == null)
            {
                return NotFound();
            }

            return View(hairSalonData);
        }

        // POST: temp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HairSalons == null)
            {
                return Problem("Entity set 'HairDbContext.HairSalons'  is null.");
            }
            var hairSalonData = await _context.HairSalons.FindAsync(id);
            if (hairSalonData != null)
            {
                _context.HairSalons.Remove(hairSalonData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HairSalonDataExists(int id)
        {
          return (_context.HairSalons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
