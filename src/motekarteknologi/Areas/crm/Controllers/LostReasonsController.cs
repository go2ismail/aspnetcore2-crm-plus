using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using motekarteknologi.Areas.crm.Models;
using motekarteknologi.Data;

namespace motekarteknologi.Areas.crm.Controllers
{
    [Area("crm")]
    public class LostReasonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LostReasonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/LostReasons
        public async Task<IActionResult> Index()
        {
            return View(await _context.LostReason.ToListAsync());
        }

        // GET: crm/LostReasons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lostReason = await _context.LostReason
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lostReason == null)
            {
                return NotFound();
            }

            return View(lostReason);
        }

        // GET: crm/LostReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/LostReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] LostReason lostReason)
        {
            if (ModelState.IsValid)
            {
                lostReason.ID = Guid.NewGuid();
                _context.Add(lostReason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lostReason);
        }

        // GET: crm/LostReasons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lostReason = await _context.LostReason.SingleOrDefaultAsync(m => m.ID == id);
            if (lostReason == null)
            {
                return NotFound();
            }
            return View(lostReason);
        }

        // POST: crm/LostReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] LostReason lostReason)
        {
            if (id != lostReason.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lostReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LostReasonExists(lostReason.ID))
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
            return View(lostReason);
        }

        // GET: crm/LostReasons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lostReason = await _context.LostReason
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lostReason == null)
            {
                return NotFound();
            }

            return View(lostReason);
        }

        // POST: crm/LostReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lostReason = await _context.LostReason.SingleOrDefaultAsync(m => m.ID == id);
            _context.LostReason.Remove(lostReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LostReasonExists(Guid id)
        {
            return _context.LostReason.Any(e => e.ID == id);
        }
    }
}
