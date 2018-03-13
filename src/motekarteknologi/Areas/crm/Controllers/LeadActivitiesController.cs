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
    public class LeadActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: crm/LeadActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeadActivity.ToListAsync());
        }

        // GET: crm/LeadActivities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadActivity = await _context.LeadActivity
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadActivity == null)
            {
                return NotFound();
            }

            return View(leadActivity);
        }

        // GET: crm/LeadActivities/Create
        public IActionResult Create(Guid? MasterID)
        {
            if (MasterID != null)
            {
                ViewBag.MasterID = MasterID;
            }

            

            return View();
        }

        // POST: crm/LeadActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("From,To,ID,CreatedDateUtc,IsActive,Name,Description")] LeadActivity leadActivity, Guid? ID)
        {
            if (ModelState.IsValid)
            {
                var masterid = ID;
                Lead lead = await _context.Lead.Where(x => x.ID.Equals(masterid)).FirstOrDefaultAsync();
                leadActivity.ID = Guid.NewGuid();
                leadActivity.Lead = lead;
                _context.Add(leadActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "Leads", new { ID = masterid });
            }
            return View(leadActivity);
        }

        // GET: crm/LeadActivities/Edit/5
        public async Task<IActionResult> Edit(Guid? id,
            Guid? MasterID,
            string MasterControllerName,
           string MasterActionName)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (MasterID != null &&
              !String.IsNullOrEmpty(MasterControllerName) &&
              !String.IsNullOrEmpty(MasterActionName))
            {
                return RedirectToAction(MasterActionName, MasterControllerName, new { ID = MasterID });
            }

            var leadActivity = await _context.LeadActivity.SingleOrDefaultAsync(m => m.ID == id);
            if (leadActivity == null)
            {
                return NotFound();
            }
            return View(leadActivity);
        }

        // POST: crm/LeadActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("From,To,ID,CreatedDateUtc,IsActive,Name,Description")] LeadActivity leadActivity)
        {
            if (id != leadActivity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadActivityExists(leadActivity.ID))
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
            return View(leadActivity);
        }

        // GET: crm/LeadActivities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadActivity = await _context.LeadActivity
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadActivity == null)
            {
                return NotFound();
            }

            return View(leadActivity);
        }

        // POST: crm/LeadActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var leadActivity = await _context.LeadActivity.SingleOrDefaultAsync(m => m.ID == id);
            _context.LeadActivity.Remove(leadActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadActivityExists(Guid id)
        {
            return _context.LeadActivity.Any(e => e.ID == id);
        }
    }
}
