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
    public class TbcategoriesController : Controller
    {
        private readonly EcommerceContext _context;

        public TbcategoriesController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbcategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbcategories.ToListAsync());
        }

        // GET: Tbcategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbcategory = await _context.Tbcategories
                .FirstOrDefaultAsync(m => m.PkCategory == id);
            if (tbcategory == null)
            {
                return NotFound();
            }

            return View(tbcategory);
        }

        // GET: Tbcategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkCategory,Name,UrlCategory,Description,Status,CreatedAt,UpdatedAt")] Tbcategory tbcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbcategory);
        }

        // GET: Tbcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbcategory = await _context.Tbcategories.FindAsync(id);
            if (tbcategory == null)
            {
                return NotFound();
            }
            return View(tbcategory);
        }

        // POST: Tbcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkCategory,Name,UrlCategory,Description,Status,CreatedAt,UpdatedAt")] Tbcategory tbcategory)
        {
            if (id != tbcategory.PkCategory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbcategoryExists(tbcategory.PkCategory))
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
            return View(tbcategory);
        }

        // GET: Tbcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbcategory = await _context.Tbcategories
                .FirstOrDefaultAsync(m => m.PkCategory == id);
            if (tbcategory == null)
            {
                return NotFound();
            }

            return View(tbcategory);
        }

        // POST: Tbcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbcategory = await _context.Tbcategories.FindAsync(id);
            if (tbcategory != null)
            {
                _context.Tbcategories.Remove(tbcategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbcategoryExists(int id)
        {
            return _context.Tbcategories.Any(e => e.PkCategory == id);
        }
    }
}
