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
    public class TbrolesController : Controller
    {
        private readonly EcommerceContext _context;

        public TbrolesController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbroles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbroles.ToListAsync());
        }

        // GET: Tbroles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbrole = await _context.Tbroles
                .FirstOrDefaultAsync(m => m.PkRole == id);
            if (tbrole == null)
            {
                return NotFound();
            }

            return View(tbrole);
        }

        // GET: Tbroles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbroles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkRole,Role,Status,CreatedAt,UpdatedAt")] Tbrole tbrole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbrole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbrole);
        }

        // GET: Tbroles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbrole = await _context.Tbroles.FindAsync(id);
            if (tbrole == null)
            {
                return NotFound();
            }
            return View(tbrole);
        }

        // POST: Tbroles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkRole,Role,Status,CreatedAt,UpdatedAt")] Tbrole tbrole)
        {
            if (id != tbrole.PkRole)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbrole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbroleExists(tbrole.PkRole))
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
            return View(tbrole);
        }

        // GET: Tbroles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbrole = await _context.Tbroles
                .FirstOrDefaultAsync(m => m.PkRole == id);
            if (tbrole == null)
            {
                return NotFound();
            }

            return View(tbrole);
        }

        // POST: Tbroles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbrole = await _context.Tbroles.FindAsync(id);
            if (tbrole != null)
            {
                _context.Tbroles.Remove(tbrole);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbroleExists(int id)
        {
            return _context.Tbroles.Any(e => e.PkRole == id);
        }
    }
}
