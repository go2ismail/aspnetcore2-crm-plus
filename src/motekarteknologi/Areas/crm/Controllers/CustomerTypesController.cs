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
    public class CustomerTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/CustomerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerType.ToListAsync());
        }

        // GET: crm/CustomerTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // GET: crm/CustomerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/CustomerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                customerType.ID = Guid.NewGuid();
                _context.Add(customerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerType);
        }

        // GET: crm/CustomerTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType.SingleOrDefaultAsync(m => m.ID == id);
            if (customerType == null)
            {
                return NotFound();
            }
            return View(customerType);
        }

        // POST: crm/CustomerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] CustomerType customerType)
        {
            if (id != customerType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTypeExists(customerType.ID))
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
            return View(customerType);
        }

        // GET: crm/CustomerTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // POST: crm/CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerType = await _context.CustomerType.SingleOrDefaultAsync(m => m.ID == id);
            _context.CustomerType.Remove(customerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTypeExists(Guid id)
        {
            return _context.CustomerType.Any(e => e.ID == id);
        }
    }
}
