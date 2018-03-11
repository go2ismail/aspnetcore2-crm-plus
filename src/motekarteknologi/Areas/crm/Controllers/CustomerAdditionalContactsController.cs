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
    public class CustomerAdditionalContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerAdditionalContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/CustomerAdditionalContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerAdditionalContact.ToListAsync());
        }

        // GET: crm/CustomerAdditionalContacts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAdditionalContact = await _context.CustomerAdditionalContact
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerAdditionalContact == null)
            {
                return NotFound();
            }

            return View(customerAdditionalContact);
        }

        // GET: crm/CustomerAdditionalContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/CustomerAdditionalContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] CustomerAdditionalContact customerAdditionalContact)
        {
            if (ModelState.IsValid)
            {
                customerAdditionalContact.ID = Guid.NewGuid();
                _context.Add(customerAdditionalContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerAdditionalContact);
        }

        // GET: crm/CustomerAdditionalContacts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAdditionalContact = await _context.CustomerAdditionalContact.SingleOrDefaultAsync(m => m.ID == id);
            if (customerAdditionalContact == null)
            {
                return NotFound();
            }
            return View(customerAdditionalContact);
        }

        // POST: crm/CustomerAdditionalContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] CustomerAdditionalContact customerAdditionalContact)
        {
            if (id != customerAdditionalContact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAdditionalContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAdditionalContactExists(customerAdditionalContact.ID))
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
            return View(customerAdditionalContact);
        }

        // GET: crm/CustomerAdditionalContacts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAdditionalContact = await _context.CustomerAdditionalContact
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerAdditionalContact == null)
            {
                return NotFound();
            }

            return View(customerAdditionalContact);
        }

        // POST: crm/CustomerAdditionalContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerAdditionalContact = await _context.CustomerAdditionalContact.SingleOrDefaultAsync(m => m.ID == id);
            _context.CustomerAdditionalContact.Remove(customerAdditionalContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAdditionalContactExists(Guid id)
        {
            return _context.CustomerAdditionalContact.Any(e => e.ID == id);
        }
    }
}
