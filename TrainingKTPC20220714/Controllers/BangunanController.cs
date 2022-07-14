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
    public class BangunanController : Controller
    {
        private readonly TrainingKTPC20220714Context _context;

        public BangunanController(TrainingKTPC20220714Context context)
        {
            _context = context;
        }

        // GET: Bangunan
        public async Task<IActionResult> Index()
        {
            var trainingKTPC20220714Context = _context.Bangunan.Include(b => b.lokasi);
            return View(await trainingKTPC20220714Context.ToListAsync());
        }

        // GET: Bangunan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bangunan == null)
            {
                return NotFound();
            }

            var bangunan = await _context.Bangunan
                .Include(b => b.lokasi)
                .FirstOrDefaultAsync(m => m.IdKey == id);
            if (bangunan == null)
            {
                return NotFound();
            }

            return View(bangunan);
        }

        // GET: Bangunan/Create
        public IActionResult Create()
        {
            ViewData["LokasiID"] = new SelectList(_context.Lokasi, "Id", "Name");
            return View();
        }

        // POST: Bangunan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKey,Name,Alamat,BilTingkat,Kategori,LokasiID")] Bangunan bangunan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bangunan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LokasiID"] = new SelectList(_context.Lokasi, "Id", "Name", bangunan.LokasiID);
            return View(bangunan);
        }

        // GET: Bangunan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bangunan == null)
            {
                return NotFound();
            }

            var bangunan = await _context.Bangunan.FindAsync(id);
            if (bangunan == null)
            {
                return NotFound();
            }
            ViewData["LokasiID"] = new SelectList(_context.Lokasi, "Id", "Name", bangunan.LokasiID);
            return View(bangunan);
        }

        // POST: Bangunan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKey,Name,Alamat,BilTingkat,Kategori,LokasiID")] Bangunan bangunan)
        {
            if (id != bangunan.IdKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangunan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangunanExists(bangunan.IdKey))
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
            ViewData["LokasiID"] = new SelectList(_context.Lokasi, "Id", "Name", bangunan.LokasiID);
            return View(bangunan);
        }

        // GET: Bangunan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bangunan == null)
            {
                return NotFound();
            }

            var bangunan = await _context.Bangunan
                .Include(b => b.lokasi)
                .FirstOrDefaultAsync(m => m.IdKey == id);
            if (bangunan == null)
            {
                return NotFound();
            }

            return View(bangunan);
        }

        // POST: Bangunan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bangunan == null)
            {
                return Problem("Entity set 'TrainingKTPC20220714Context.Bangunan'  is null.");
            }
            var bangunan = await _context.Bangunan.FindAsync(id);
            if (bangunan != null)
            {
                _context.Bangunan.Remove(bangunan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BangunanExists(int id)
        {
          return (_context.Bangunan?.Any(e => e.IdKey == id)).GetValueOrDefault();
        }
    }
}
