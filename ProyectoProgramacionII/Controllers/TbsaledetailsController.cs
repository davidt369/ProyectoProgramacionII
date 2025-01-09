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
    public class TbsaledetailsController : Controller
    {
        private readonly EcommerceContext _context;

        public TbsaledetailsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbsaledetails
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.Tbsaledetails.Include(t => t.FkProductNavigation).Include(t => t.FkSaleNavigation);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: Tbsaledetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsaledetail = await _context.Tbsaledetails
                .Include(t => t.FkProductNavigation)
                .Include(t => t.FkSaleNavigation)
                .FirstOrDefaultAsync(m => m.PkSaledetail == id);
            if (tbsaledetail == null)
            {
                return NotFound();
            }

            return View(tbsaledetail);
        }

        // GET: Tbsaledetails/Create
        public IActionResult Create()
        {
            ViewData["FkProduct"] = new SelectList(_context.Tbproducts, "PkProduct", "PkProduct");
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale");
            return View();
        }

        // POST: Tbsaledetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkSaledetail,FkSale,FkProduct,Quantity,UnitPrice,Subtotal,Status,CreatedAt,UpdatedAt")] Tbsaledetail tbsaledetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbsaledetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkProduct"] = new SelectList(_context.Tbproducts, "PkProduct", "PkProduct", tbsaledetail.FkProduct);
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale", tbsaledetail.FkSale);
            return View(tbsaledetail);
        }

        // GET: Tbsaledetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsaledetail = await _context.Tbsaledetails.FindAsync(id);
            if (tbsaledetail == null)
            {
                return NotFound();
            }
            ViewData["FkProduct"] = new SelectList(_context.Tbproducts, "PkProduct", "PkProduct", tbsaledetail.FkProduct);
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale", tbsaledetail.FkSale);
            return View(tbsaledetail);
        }

        // POST: Tbsaledetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkSaledetail,FkSale,FkProduct,Quantity,UnitPrice,Subtotal,Status,CreatedAt,UpdatedAt")] Tbsaledetail tbsaledetail)
        {
            if (id != tbsaledetail.PkSaledetail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbsaledetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbsaledetailExists(tbsaledetail.PkSaledetail))
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
            ViewData["FkProduct"] = new SelectList(_context.Tbproducts, "PkProduct", "PkProduct", tbsaledetail.FkProduct);
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale", tbsaledetail.FkSale);
            return View(tbsaledetail);
        }

        // GET: Tbsaledetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsaledetail = await _context.Tbsaledetails
                .Include(t => t.FkProductNavigation)
                .Include(t => t.FkSaleNavigation)
                .FirstOrDefaultAsync(m => m.PkSaledetail == id);
            if (tbsaledetail == null)
            {
                return NotFound();
            }

            return View(tbsaledetail);
        }

        // POST: Tbsaledetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbsaledetail = await _context.Tbsaledetails.FindAsync(id);
            if (tbsaledetail != null)
            {
                _context.Tbsaledetails.Remove(tbsaledetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbsaledetailExists(int id)
        {
            return _context.Tbsaledetails.Any(e => e.PkSaledetail == id);
        }
    }
}
