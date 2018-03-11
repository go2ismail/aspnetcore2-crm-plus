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
    public class LeadAdditionalContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadAdditionalContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/LeadAdditionalContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeadAdditionalContact.ToListAsync());
        }

        // GET: crm/LeadAdditionalContacts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadAdditionalContact = await _context.LeadAdditionalContact
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadAdditionalContact == null)
            {
                return NotFound();
            }

            return View(leadAdditionalContact);
        }

        // GET: crm/LeadAdditionalContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/LeadAdditionalContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactName,JobPosition,Email,Phone,Mobile,ID,CreatedDateUtc,IsActive,Name,Description")] LeadAdditionalContact leadAdditionalContact)
        {
            if (ModelState.IsValid)
            {
                leadAdditionalContact.ID = Guid.NewGuid();
                _context.Add(leadAdditionalContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadAdditionalContact);
        }

        // GET: crm/LeadAdditionalContacts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadAdditionalContact = await _context.LeadAdditionalContact.SingleOrDefaultAsync(m => m.ID == id);
            if (leadAdditionalContact == null)
            {
                return NotFound();
            }
            return View(leadAdditionalContact);
        }

        // POST: crm/LeadAdditionalContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ContactName,JobPosition,Email,Phone,Mobile,ID,CreatedDateUtc,IsActive,Name,Description")] LeadAdditionalContact leadAdditionalContact)
        {
            if (id != leadAdditionalContact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadAdditionalContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadAdditionalContactExists(leadAdditionalContact.ID))
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
            return View(leadAdditionalContact);
        }

        // GET: crm/LeadAdditionalContacts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadAdditionalContact = await _context.LeadAdditionalContact
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadAdditionalContact == null)
            {
                return NotFound();
            }

            return View(leadAdditionalContact);
        }

        // POST: crm/LeadAdditionalContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var leadAdditionalContact = await _context.LeadAdditionalContact.SingleOrDefaultAsync(m => m.ID == id);
            _context.LeadAdditionalContact.Remove(leadAdditionalContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadAdditionalContactExists(Guid id)
        {
            return _context.LeadAdditionalContact.Any(e => e.ID == id);
        }
    }
}
