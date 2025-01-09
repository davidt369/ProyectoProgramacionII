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
    public class TbusersController : Controller
    {
        private readonly EcommerceContext _context;

        public TbusersController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: Tbusers
        public async Task<IActionResult> Index()
        {
            var ecommerceContext = _context.Tbusers.Include(t => t.FkRoleNavigation);
            return View(await ecommerceContext.ToListAsync());
        }

        // GET: Tbusers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbuser = await _context.Tbusers
                .Include(t => t.FkRoleNavigation)
                .FirstOrDefaultAsync(m => m.PkUser == id);
            if (tbuser == null)
            {
                return NotFound();
            }

            return View(tbuser);
        }

        // GET: Tbusers/Create
        public IActionResult Create()
        {
            ViewData["FkRole"] = new SelectList(_context.Tbroles, "PkRole", "PkRole");
            return View();
        }

        // POST: Tbusers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkUser,FkRole,FirstName,LastName,Email,Password,ProfileImage,Status,CreatedAt,UpdatedAt")] Tbuser tbuser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbuser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkRole"] = new SelectList(_context.Tbroles, "PkRole", "PkRole", tbuser.FkRole);
            return View(tbuser);
        }

        // GET: Tbusers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbuser = await _context.Tbusers.FindAsync(id);
            if (tbuser == null)
            {
                return NotFound();
            }
            ViewData["FkRole"] = new SelectList(_context.Tbroles, "PkRole", "PkRole", tbuser.FkRole);
            return View(tbuser);
        }

        // POST: Tbusers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkUser,FkRole,FirstName,LastName,Email,Password,ProfileImage,Status,CreatedAt,UpdatedAt")] Tbuser tbuser)
        {
            if (id != tbuser.PkUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbuserExists(tbuser.PkUser))
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
            ViewData["FkRole"] = new SelectList(_context.Tbroles, "PkRole", "PkRole", tbuser.FkRole);
            return View(tbuser);
        }

        // GET: Tbusers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbuser = await _context.Tbusers
                .Include(t => t.FkRoleNavigation)
                .FirstOrDefaultAsync(m => m.PkUser == id);
            if (tbuser == null)
            {
                return NotFound();
            }

            return View(tbuser);
        }

        // POST: Tbusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbuser = await _context.Tbusers.FindAsync(id);
            if (tbuser != null)
            {
                _context.Tbusers.Remove(tbuser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbuserExists(int id)
        {
            return _context.Tbusers.Any(e => e.PkUser == id);
        }
    }
}
