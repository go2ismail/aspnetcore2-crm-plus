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
    public class CustomerActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/CustomerActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerActivity.ToListAsync());
        }

        // GET: crm/CustomerActivities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerActivity = await _context.CustomerActivity
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerActivity == null)
            {
                return NotFound();
            }

            return View(customerActivity);
        }

        // GET: crm/CustomerActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/CustomerActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("From,To,ID,CreatedDateUtc,IsActive,Name,Description")] CustomerActivity customerActivity)
        {
            if (ModelState.IsValid)
            {
                customerActivity.ID = Guid.NewGuid();
                _context.Add(customerActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerActivity);
        }

        // GET: crm/CustomerActivities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerActivity = await _context.CustomerActivity.SingleOrDefaultAsync(m => m.ID == id);
            if (customerActivity == null)
            {
                return NotFound();
            }
            return View(customerActivity);
        }

        // POST: crm/CustomerActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("From,To,ID,CreatedDateUtc,IsActive,Name,Description")] CustomerActivity customerActivity)
        {
            if (id != customerActivity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerActivityExists(customerActivity.ID))
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
            return View(customerActivity);
        }

        // GET: crm/CustomerActivities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerActivity = await _context.CustomerActivity
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerActivity == null)
            {
                return NotFound();
            }

            return View(customerActivity);
        }

        // POST: crm/CustomerActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerActivity = await _context.CustomerActivity.SingleOrDefaultAsync(m => m.ID == id);
            _context.CustomerActivity.Remove(customerActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerActivityExists(Guid id)
        {
            return _context.CustomerActivity.Any(e => e.ID == id);
        }
    }
}
