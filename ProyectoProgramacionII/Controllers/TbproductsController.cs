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
    public class TbproductsController : Controller
    {
        private readonly EcommerceContext _context;

        public TbproductsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbproducts
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.Tbproducts.Include(t => t.FkCategoryNavigation);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: Tbproducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbproduct = await _context.Tbproducts
                .Include(t => t.FkCategoryNavigation)
                .FirstOrDefaultAsync(m => m.PkProduct == id);
            if (tbproduct == null)
            {
                return NotFound();
            }

            return View(tbproduct);
        }

        // GET: Tbproducts/Create
        public IActionResult Create()
        {
            ViewData["FkCategory"] = new SelectList(_context.Tbcategories, "PkCategory", "PkCategory");
            return View();
        }

        // POST: Tbproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkProduct,FkCategory,Name,UrlImage,UrlProduct,RegularPrice,OfferPrice,Stock,Description,ProfileImage,Status,CreatedAt,UpdatedAt")] Tbproduct tbproduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbproduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCategory"] = new SelectList(_context.Tbcategories, "PkCategory", "PkCategory", tbproduct.FkCategory);
            return View(tbproduct);
        }

        // GET: Tbproducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbproduct = await _context.Tbproducts.FindAsync(id);
            if (tbproduct == null)
            {
                return NotFound();
            }
            ViewData["FkCategory"] = new SelectList(_context.Tbcategories, "PkCategory", "PkCategory", tbproduct.FkCategory);
            return View(tbproduct);
        }

        // POST: Tbproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkProduct,FkCategory,Name,UrlImage,UrlProduct,RegularPrice,OfferPrice,Stock,Description,ProfileImage,Status,CreatedAt,UpdatedAt")] Tbproduct tbproduct)
        {
            if (id != tbproduct.PkProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbproduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbproductExists(tbproduct.PkProduct))
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
            ViewData["FkCategory"] = new SelectList(_context.Tbcategories, "PkCategory", "PkCategory", tbproduct.FkCategory);
            return View(tbproduct);
        }

        // GET: Tbproducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbproduct = await _context.Tbproducts
                .Include(t => t.FkCategoryNavigation)
                .FirstOrDefaultAsync(m => m.PkProduct == id);
            if (tbproduct == null)
            {
                return NotFound();
            }

            return View(tbproduct);
        }

        // POST: Tbproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbproduct = await _context.Tbproducts.FindAsync(id);
            if (tbproduct != null)
            {
                _context.Tbproducts.Remove(tbproduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbproductExists(int id)
        {
            return _context.Tbproducts.Any(e => e.PkProduct == id);
        }
    }
}
