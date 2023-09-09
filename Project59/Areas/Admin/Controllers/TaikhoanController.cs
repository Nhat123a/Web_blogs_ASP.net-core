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
    public class TaikhoanController : Controller
    {
        Project59Context _context = new Project59Context();

        // GET: Admin/Taikhoan
        [Route("quan-li-tai-khoan.html", Name = "taikhoan")]
        public async Task<IActionResult> Index()
        {
            var project59Context = _context.Taikhoans.Include(t => t.Role);
            return View(await project59Context.ToListAsync());
        }

        // GET: Admin/Taikhoan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Taikhoans == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // GET: Admin/Taikhoan/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Truycaps, "RoleId", "RoleId");
            return View();
        }

        // POST: Admin/Taikhoan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hoten,Ngaysinh,Diachi,Email,Sdt,Trangthai,Mota,RoleId,Taikhoan1,Matkhau")] Taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taikhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Truycaps, "RoleId", "RoleId", taikhoan.RoleId);
            return View(taikhoan);
        }

        // GET: Admin/Taikhoan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Taikhoans == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Truycaps, "RoleId", "RoleId", taikhoan.RoleId);
            return View(taikhoan);
        }

        // POST: Admin/Taikhoan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hoten,Ngaysinh,Diachi,Email,Sdt,Trangthai,Mota,RoleId,Taikhoan1,Matkhau")] Taikhoan taikhoan)
        {
            if (id != taikhoan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taikhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaikhoanExists(taikhoan.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Truycaps, "RoleId", "RoleId", taikhoan.RoleId);
            return View(taikhoan);
        }

        // GET: Admin/Taikhoan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Taikhoans == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // POST: Admin/Taikhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Taikhoans == null)
            {
                return Problem("Entity set 'Project59Context.Taikhoans'  is null.");
            }
            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan != null)
            {
                _context.Taikhoans.Remove(taikhoan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaikhoanExists(int id)
        {
          return (_context.Taikhoans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
