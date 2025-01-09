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
    public class TbpaymentreceiptsController : Controller
    {
        private readonly EcommerceContext _context;

        public TbpaymentreceiptsController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbpaymentreceipts
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.Tbpaymentreceipts.Include(t => t.FkPaymentmethodNavigation).Include(t => t.FkSaleNavigation);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: Tbpaymentreceipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbpaymentreceipt = await _context.Tbpaymentreceipts
                .Include(t => t.FkPaymentmethodNavigation)
                .Include(t => t.FkSaleNavigation)
                .FirstOrDefaultAsync(m => m.PkPaymentreceipt == id);
            if (tbpaymentreceipt == null)
            {
                return NotFound();
            }

            return View(tbpaymentreceipt);
        }

        // GET: Tbpaymentreceipts/Create
        public IActionResult Create()
        {
            ViewData["FkPaymentmethod"] = new SelectList(_context.Tbpaymentmethods, "PkPaymentmethod", "PkPaymentmethod");
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale");
            return View();
        }

        // POST: Tbpaymentreceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkPaymentreceipt,FkPaymentmethod,FkSale,ReceiptImage,ReceiptDate,ReceiptTime,Status,CreatedAt,UpdatedAt")] Tbpaymentreceipt tbpaymentreceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbpaymentreceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkPaymentmethod"] = new SelectList(_context.Tbpaymentmethods, "PkPaymentmethod", "PkPaymentmethod", tbpaymentreceipt.FkPaymentmethod);
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale", tbpaymentreceipt.FkSale);
            return View(tbpaymentreceipt);
        }

        // GET: Tbpaymentreceipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbpaymentreceipt = await _context.Tbpaymentreceipts.FindAsync(id);
            if (tbpaymentreceipt == null)
            {
                return NotFound();
            }
            ViewData["FkPaymentmethod"] = new SelectList(_context.Tbpaymentmethods, "PkPaymentmethod", "PkPaymentmethod", tbpaymentreceipt.FkPaymentmethod);
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale", tbpaymentreceipt.FkSale);
            return View(tbpaymentreceipt);
        }

        // POST: Tbpaymentreceipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkPaymentreceipt,FkPaymentmethod,FkSale,ReceiptImage,ReceiptDate,ReceiptTime,Status,CreatedAt,UpdatedAt")] Tbpaymentreceipt tbpaymentreceipt)
        {
            if (id != tbpaymentreceipt.PkPaymentreceipt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbpaymentreceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbpaymentreceiptExists(tbpaymentreceipt.PkPaymentreceipt))
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
            ViewData["FkPaymentmethod"] = new SelectList(_context.Tbpaymentmethods, "PkPaymentmethod", "PkPaymentmethod", tbpaymentreceipt.FkPaymentmethod);
            ViewData["FkSale"] = new SelectList(_context.Tbsales, "PkSale", "PkSale", tbpaymentreceipt.FkSale);
            return View(tbpaymentreceipt);
        }

        // GET: Tbpaymentreceipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbpaymentreceipt = await _context.Tbpaymentreceipts
                .Include(t => t.FkPaymentmethodNavigation)
                .Include(t => t.FkSaleNavigation)
                .FirstOrDefaultAsync(m => m.PkPaymentreceipt == id);
            if (tbpaymentreceipt == null)
            {
                return NotFound();
            }

            return View(tbpaymentreceipt);
        }

        // POST: Tbpaymentreceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbpaymentreceipt = await _context.Tbpaymentreceipts.FindAsync(id);
            if (tbpaymentreceipt != null)
            {
                _context.Tbpaymentreceipts.Remove(tbpaymentreceipt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbpaymentreceiptExists(int id)
        {
            return _context.Tbpaymentreceipts.Any(e => e.PkPaymentreceipt == id);
        }
    }
}
