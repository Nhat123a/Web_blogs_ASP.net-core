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
    public class TintucController : Controller
    {
        Project59Context _context = new Project59Context();

        // GET: Admin/Tintuc
        [Route("quan-li-tin-tuc.html", Name = "tin")]
        public async Task<IActionResult> Index()
        {
              return _context.Tintucs != null ? 
                          View(await _context.Tintucs.ToListAsync()) :
                          Problem("Entity set 'Project59Context.Tintucs'  is null.");
        }

        // GET: Admin/Tintuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tintucs == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // GET: Admin/Tintuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tintuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ngay,Ten,Tieude,Noidung,Trangthai,Img,Tim,Cmt,Share,Loai")] Tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tintuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tintuc);
        }

        // GET: Admin/Tintuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tintucs == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs.FindAsync(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            return View(tintuc);
        }

        // POST: Admin/Tintuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ngay,Ten,Tieude,Noidung,Trangthai,Img,Tim,Cmt,Share,Loai")] Tintuc tintuc)
        {
            if (id != tintuc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tintuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TintucExists(tintuc.Id))
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
            return View(tintuc);
        }

        // GET: Admin/Tintuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tintucs == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // POST: Admin/Tintuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tintucs == null)
            {
                return Problem("Entity set 'Project59Context.Tintucs'  is null.");
            }
            var tintuc = await _context.Tintucs.FindAsync(id);
            if (tintuc != null)
            {
                _context.Tintucs.Remove(tintuc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TintucExists(int id)
        {
          return (_context.Tintucs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
