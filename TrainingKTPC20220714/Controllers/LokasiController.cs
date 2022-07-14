using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingKTPC20220714.Data;
using TrainingKTPC20220714.Models;

namespace TrainingKTPC20220714.Controllers
{
    public class LokasiController : Controller
    {
        private readonly TrainingKTPC20220714Context _context;

        public LokasiController(TrainingKTPC20220714Context context)
        {
            _context = context;
        }

        // GET: Lokasi
        public async Task<IActionResult> Index()
        {
              return _context.Lokasi != null ? 
                          View(await _context.Lokasi.ToListAsync()) :
                          Problem("Entity set 'TrainingKTPC20220714Context.Lokasi'  is null.");
        }

        // GET: Lokasi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lokasi == null)
            {
                return NotFound();
            }

            var lokasi = await _context.Lokasi.Include(x => x.bangunanList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lokasi == null)
            {
                return NotFound();
            }

            return View(lokasi);
        }

        // GET: Lokasi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokasi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Lokasi lokasi)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(lokasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokasi);
        }

        // GET: Lokasi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lokasi == null)
            {
                return NotFound();
            }

            var lokasi = await _context.Lokasi.FindAsync(id);
            if (lokasi == null)
            {
                return NotFound();
            }
            return View(lokasi);
        }

        // POST: Lokasi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Lokasi lokasi)
        {
            if (id != lokasi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokasiExists(lokasi.Id))
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
            return View(lokasi);
        }

        // GET: Lokasi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lokasi == null)
            {
                return NotFound();
            }

            var lokasi = await _context.Lokasi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lokasi == null)
            {
                return NotFound();
            }

            return View(lokasi);
        }

        // POST: Lokasi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lokasi == null)
            {
                return Problem("Entity set 'TrainingKTPC20220714Context.Lokasi'  is null.");
            }
            var lokasi = await _context.Lokasi.FindAsync(id);
            if (lokasi != null)
            {
                _context.Lokasi.Remove(lokasi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokasiExists(int id)
        {
          return (_context.Lokasi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
