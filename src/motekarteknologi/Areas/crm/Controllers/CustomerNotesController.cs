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
    public class CustomerNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/CustomerNotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerNote.ToListAsync());
        }

        // GET: crm/CustomerNotes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerNote = await _context.CustomerNote
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerNote == null)
            {
                return NotFound();
            }

            return View(customerNote);
        }

        // GET: crm/CustomerNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/CustomerNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] CustomerNote customerNote)
        {
            if (ModelState.IsValid)
            {
                customerNote.ID = Guid.NewGuid();
                _context.Add(customerNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerNote);
        }

        // GET: crm/CustomerNotes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerNote = await _context.CustomerNote.SingleOrDefaultAsync(m => m.ID == id);
            if (customerNote == null)
            {
                return NotFound();
            }
            return View(customerNote);
        }

        // POST: crm/CustomerNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] CustomerNote customerNote)
        {
            if (id != customerNote.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerNoteExists(customerNote.ID))
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
            return View(customerNote);
        }

        // GET: crm/CustomerNotes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerNote = await _context.CustomerNote
                .SingleOrDefaultAsync(m => m.ID == id);
            if (customerNote == null)
            {
                return NotFound();
            }

            return View(customerNote);
        }

        // POST: crm/CustomerNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerNote = await _context.CustomerNote.SingleOrDefaultAsync(m => m.ID == id);
            _context.CustomerNote.Remove(customerNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerNoteExists(Guid id)
        {
            return _context.CustomerNote.Any(e => e.ID == id);
        }
    }
}
