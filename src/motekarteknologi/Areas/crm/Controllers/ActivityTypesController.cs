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
    public class ActivityTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

      

        // GET: crm/ActivityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityType.ToListAsync());
        }

        // GET: crm/ActivityTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityType = await _context.ActivityType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (activityType == null)
            {
                return NotFound();
            }

            return View(activityType);
        }

        // GET: crm/ActivityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/ActivityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumberofDays,ID,CreatedDateUtc,IsActive,Name,Description")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                activityType.ID = Guid.NewGuid();
                _context.Add(activityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityType);
        }

        // GET: crm/ActivityTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityType = await _context.ActivityType.SingleOrDefaultAsync(m => m.ID == id);
            if (activityType == null)
            {
                return NotFound();
            }
            return View(activityType);
        }

        // POST: crm/ActivityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("NumberofDays,ID,CreatedDateUtc,IsActive,Name,Description")] ActivityType activityType)
        {
            if (id != activityType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityTypeExists(activityType.ID))
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
            return View(activityType);
        }

        // GET: crm/ActivityTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityType = await _context.ActivityType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (activityType == null)
            {
                return NotFound();
            }

            return View(activityType);
        }

        // POST: crm/ActivityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var activityType = await _context.ActivityType.SingleOrDefaultAsync(m => m.ID == id);
            _context.ActivityType.Remove(activityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityTypeExists(Guid id)
        {
            return _context.ActivityType.Any(e => e.ID == id);
        }
    }
}
