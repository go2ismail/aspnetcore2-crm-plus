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
    public class LeadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/Leads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lead.ToListAsync());
        }

        // GET: crm/Leads/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }

        // GET: crm/Leads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/Leads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactName,JobPosition,Email,Phone,Mobile,Priority,IsQualified,Street,Street2,City,State,ZIP,Country,Website,ID,CreatedDateUtc,IsActive,Name,Description")] Lead lead)
        {
            if (ModelState.IsValid)
            {
                lead.ID = Guid.NewGuid();
                _context.Add(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lead);
        }

        // GET: crm/Leads/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead.SingleOrDefaultAsync(m => m.ID == id);
            if (lead == null)
            {
                return NotFound();
            }
            return View(lead);
        }

        // POST: crm/Leads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ContactName,JobPosition,Email,Phone,Mobile,Priority,IsQualified,Street,Street2,City,State,ZIP,Country,Website,ID,CreatedDateUtc,IsActive,Name,Description")] Lead lead)
        {
            if (id != lead.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadExists(lead.ID))
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
            return View(lead);
        }

        // GET: crm/Leads/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lead = await _context.Lead
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lead == null)
            {
                return NotFound();
            }

            return View(lead);
        }

        // POST: crm/Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lead = await _context.Lead.SingleOrDefaultAsync(m => m.ID == id);
            _context.Lead.Remove(lead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadExists(Guid id)
        {
            return _context.Lead.Any(e => e.ID == id);
        }
    }
}
