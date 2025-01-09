using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacionII.Models;

namespace ProyectoProgramacionII.Controllers
{
    public class TbsalesController : Controller
    {
        private readonly EcommerceContext _context;

        public TbsalesController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbsales
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.Tbsales.Include(t => t.FkSalestatusNavigation).Include(t => t.FkUserNavigation);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: Tbsales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsale = await _context.Tbsales
                .Include(t => t.FkSalestatusNavigation)
                .Include(t => t.FkUserNavigation)
                .FirstOrDefaultAsync(m => m.PkSale == id);
            if (tbsale == null)
            {
                return NotFound();
            }

            return View(tbsale);
        }

        // GET: Tbsales/Create
        public IActionResult Create()
        {
            ViewData["FkSalestatus"] = new SelectList(_context.Tbsalesstatuses, "PkSalestatus", "PkSalestatus");
            ViewData["FkUser"] = new SelectList(_context.Tbusers, "PkUser", "PkUser");
            return View();
        }

        // POST: Tbsales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkSale,FkUser,FkSalestatus,TotalAmount,Status,CreatedAt,UpdatedAt")] Tbsale tbsale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbsale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkSalestatus"] = new SelectList(_context.Tbsalesstatuses, "PkSalestatus", "PkSalestatus", tbsale.FkSalestatus);
            ViewData["FkUser"] = new SelectList(_context.Tbusers, "PkUser", "PkUser", tbsale.FkUser);
            return View(tbsale);
        }

        // GET: Tbsales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsale = await _context.Tbsales.FindAsync(id);
            if (tbsale == null)
            {
                return NotFound();
            }
            ViewData["FkSalestatus"] = new SelectList(_context.Tbsalesstatuses, "PkSalestatus", "PkSalestatus", tbsale.FkSalestatus);
            ViewData["FkUser"] = new SelectList(_context.Tbusers, "PkUser", "PkUser", tbsale.FkUser);
            return View(tbsale);
        }

        // POST: Tbsales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkSale,FkUser,FkSalestatus,TotalAmount,Status,CreatedAt,UpdatedAt")] Tbsale tbsale)
        {
            if (id != tbsale.PkSale)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbsale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbsaleExists(tbsale.PkSale))
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
            ViewData["FkSalestatus"] = new SelectList(_context.Tbsalesstatuses, "PkSalestatus", "PkSalestatus", tbsale.FkSalestatus);
            ViewData["FkUser"] = new SelectList(_context.Tbusers, "PkUser", "PkUser", tbsale.FkUser);
            return View(tbsale);
        }

        // GET: Tbsales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsale = await _context.Tbsales
                .Include(t => t.FkSalestatusNavigation)
                .Include(t => t.FkUserNavigation)
                .FirstOrDefaultAsync(m => m.PkSale == id);
            if (tbsale == null)
            {
                return NotFound();
            }

            return View(tbsale);
        }

        // POST: Tbsales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbsale = await _context.Tbsales.FindAsync(id);
            if (tbsale != null)
            {
                _context.Tbsales.Remove(tbsale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbsaleExists(int id)
        {
            return _context.Tbsales.Any(e => e.PkSale == id);
        }
    }
}
