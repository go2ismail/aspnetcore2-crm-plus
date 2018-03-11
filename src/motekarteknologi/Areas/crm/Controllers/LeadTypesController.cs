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
    public class LeadTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/LeadTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeadType.ToListAsync());
        }

        // GET: crm/LeadTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadType = await _context.LeadType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadType == null)
            {
                return NotFound();
            }

            return View(leadType);
        }

        // GET: crm/LeadTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/LeadTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] LeadType leadType)
        {
            if (ModelState.IsValid)
            {
                leadType.ID = Guid.NewGuid();
                _context.Add(leadType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadType);
        }

        // GET: crm/LeadTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadType = await _context.LeadType.SingleOrDefaultAsync(m => m.ID == id);
            if (leadType == null)
            {
                return NotFound();
            }
            return View(leadType);
        }

        // POST: crm/LeadTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] LeadType leadType)
        {
            if (id != leadType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadTypeExists(leadType.ID))
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
            return View(leadType);
        }

        // GET: crm/LeadTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadType = await _context.LeadType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadType == null)
            {
                return NotFound();
            }

            return View(leadType);
        }

        // POST: crm/LeadTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var leadType = await _context.LeadType.SingleOrDefaultAsync(m => m.ID == id);
            _context.LeadType.Remove(leadType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadTypeExists(Guid id)
        {
            return _context.LeadType.Any(e => e.ID == id);
        }
    }
}
