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
    public class TbsalesstatusController : Controller
    {
        private readonly EcommerceContext _context;

        public TbsalesstatusController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbsalesstatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbsalesstatuses.ToListAsync());
        }

        // GET: Tbsalesstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsalesstatus = await _context.Tbsalesstatuses
                .FirstOrDefaultAsync(m => m.PkSalestatus == id);
            if (tbsalesstatus == null)
            {
                return NotFound();
            }

            return View(tbsalesstatus);
        }

        // GET: Tbsalesstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbsalesstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkSalestatus,Name,Description,Status,CreatedAt,UpdatedAt")] Tbsalesstatus tbsalesstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbsalesstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbsalesstatus);
        }

        // GET: Tbsalesstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsalesstatus = await _context.Tbsalesstatuses.FindAsync(id);
            if (tbsalesstatus == null)
            {
                return NotFound();
            }
            return View(tbsalesstatus);
        }

        // POST: Tbsalesstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkSalestatus,Name,Description,Status,CreatedAt,UpdatedAt")] Tbsalesstatus tbsalesstatus)
        {
            if (id != tbsalesstatus.PkSalestatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbsalesstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbsalesstatusExists(tbsalesstatus.PkSalestatus))
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
            return View(tbsalesstatus);
        }

        // GET: Tbsalesstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbsalesstatus = await _context.Tbsalesstatuses
                .FirstOrDefaultAsync(m => m.PkSalestatus == id);
            if (tbsalesstatus == null)
            {
                return NotFound();
            }

            return View(tbsalesstatus);
        }

        // POST: Tbsalesstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbsalesstatus = await _context.Tbsalesstatuses.FindAsync(id);
            if (tbsalesstatus != null)
            {
                _context.Tbsalesstatuses.Remove(tbsalesstatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbsalesstatusExists(int id)
        {
            return _context.Tbsalesstatuses.Any(e => e.PkSalestatus == id);
        }
    }
}
