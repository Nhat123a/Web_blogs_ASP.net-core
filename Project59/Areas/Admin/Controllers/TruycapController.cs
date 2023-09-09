using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project59.Models;

namespace Project59.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TruycapController : Controller
    {
        Project59Context _context = new Project59Context();

        // GET: Admin/Truycap
        [Route("quan-li-truy-cap.html", Name = "truycap")]
        public async Task<IActionResult> Index()
        {
              return _context.Truycaps != null ? 
                          View(await _context.Truycaps.ToListAsync()) :
                          Problem("Entity set 'Project59Context.Truycaps'  is null.");
        }

        // GET: Admin/Truycap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Truycaps == null)
            {
                return NotFound();
            }

            var truycap = await _context.Truycaps
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (truycap == null)
            {
                return NotFound();
            }

            return View(truycap);
        }

        // GET: Admin/Truycap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Truycap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,Trangthai,Mota")] Truycap truycap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truycap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(truycap);
        }

        // GET: Admin/Truycap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Truycaps == null)
            {
                return NotFound();
            }

            var truycap = await _context.Truycaps.FindAsync(id);
            if (truycap == null)
            {
                return NotFound();
            }
            return View(truycap);
        }

        // POST: Admin/Truycap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,Trangthai,Mota")] Truycap truycap)
        {
            if (id != truycap.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truycap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruycapExists(truycap.RoleId))
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
            return View(truycap);
        }

        // GET: Admin/Truycap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Truycaps == null)
            {
                return NotFound();
            }

            var truycap = await _context.Truycaps
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (truycap == null)
            {
                return NotFound();
            }

            return View(truycap);
        }

        // POST: Admin/Truycap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Truycaps == null)
            {
                return Problem("Entity set 'Project59Context.Truycaps'  is null.");
            }
            var truycap = await _context.Truycaps.FindAsync(id);
            if (truycap != null)
            {
                _context.Truycaps.Remove(truycap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruycapExists(int id)
        {
          return (_context.Truycaps?.Any(e => e.RoleId == id)).GetValueOrDefault();
        }
    }
}
