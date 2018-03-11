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
    public class OpportunityActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpportunityActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/OpportunityActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpportunityActivity.ToListAsync());
        }

        // GET: crm/OpportunityActivities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunityActivity = await _context.OpportunityActivity
                .SingleOrDefaultAsync(m => m.ID == id);
            if (opportunityActivity == null)
            {
                return NotFound();
            }

            return View(opportunityActivity);
        }

        // GET: crm/OpportunityActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/OpportunityActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("From,To,ID,CreatedDateUtc,IsActive,Name,Description")] OpportunityActivity opportunityActivity)
        {
            if (ModelState.IsValid)
            {
                opportunityActivity.ID = Guid.NewGuid();
                _context.Add(opportunityActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opportunityActivity);
        }

        // GET: crm/OpportunityActivities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunityActivity = await _context.OpportunityActivity.SingleOrDefaultAsync(m => m.ID == id);
            if (opportunityActivity == null)
            {
                return NotFound();
            }
            return View(opportunityActivity);
        }

        // POST: crm/OpportunityActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("From,To,ID,CreatedDateUtc,IsActive,Name,Description")] OpportunityActivity opportunityActivity)
        {
            if (id != opportunityActivity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opportunityActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityActivityExists(opportunityActivity.ID))
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
            return View(opportunityActivity);
        }

        // GET: crm/OpportunityActivities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opportunityActivity = await _context.OpportunityActivity
                .SingleOrDefaultAsync(m => m.ID == id);
            if (opportunityActivity == null)
            {
                return NotFound();
            }

            return View(opportunityActivity);
        }

        // POST: crm/OpportunityActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var opportunityActivity = await _context.OpportunityActivity.SingleOrDefaultAsync(m => m.ID == id);
            _context.OpportunityActivity.Remove(opportunityActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpportunityActivityExists(Guid id)
        {
            return _context.OpportunityActivity.Any(e => e.ID == id);
        }
    }
}
