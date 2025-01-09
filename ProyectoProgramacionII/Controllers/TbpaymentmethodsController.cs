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
    public class TbpaymentmethodsController : Controller
    {
        private readonly EcommerceContext _context;

        public TbpaymentmethodsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbpaymentmethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbpaymentmethods.ToListAsync());
        }

        // GET: Tbpaymentmethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbpaymentmethod = await _context.Tbpaymentmethods
                .FirstOrDefaultAsync(m => m.PkPaymentmethod == id);
            if (tbpaymentmethod == null)
            {
                return NotFound();
            }

            return View(tbpaymentmethod);
        }

        // GET: Tbpaymentmethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tbpaymentmethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkPaymentmethod,Name,Description,QrCodeImage,Status,CreatedAt,UpdatedAt")] Tbpaymentmethod tbpaymentmethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbpaymentmethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbpaymentmethod);
        }

        // GET: Tbpaymentmethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbpaymentmethod = await _context.Tbpaymentmethods.FindAsync(id);
            if (tbpaymentmethod == null)
            {
                return NotFound();
            }
            return View(tbpaymentmethod);
        }

        // POST: Tbpaymentmethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkPaymentmethod,Name,Description,QrCodeImage,Status,CreatedAt,UpdatedAt")] Tbpaymentmethod tbpaymentmethod)
        {
            if (id != tbpaymentmethod.PkPaymentmethod)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbpaymentmethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbpaymentmethodExists(tbpaymentmethod.PkPaymentmethod))
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
            return View(tbpaymentmethod);
        }

        // GET: Tbpaymentmethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbpaymentmethod = await _context.Tbpaymentmethods
                .FirstOrDefaultAsync(m => m.PkPaymentmethod == id);
            if (tbpaymentmethod == null)
            {
                return NotFound();
            }

            return View(tbpaymentmethod);
        }

        // POST: Tbpaymentmethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbpaymentmethod = await _context.Tbpaymentmethods.FindAsync(id);
            if (tbpaymentmethod != null)
            {
                _context.Tbpaymentmethods.Remove(tbpaymentmethod);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbpaymentmethodExists(int id)
        {
            return _context.Tbpaymentmethods.Any(e => e.PkPaymentmethod == id);
        }
    }
}
