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
    public class LeadNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeadNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/LeadNotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeadNote.ToListAsync());
        }

        // GET: crm/LeadNotes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadNote = await _context.LeadNote
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadNote == null)
            {
                return NotFound();
            }

            return View(leadNote);
        }

        // GET: crm/LeadNotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/LeadNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] LeadNote leadNote)
        {
            if (ModelState.IsValid)
            {
                leadNote.ID = Guid.NewGuid();
                _context.Add(leadNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadNote);
        }

        // GET: crm/LeadNotes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadNote = await _context.LeadNote.SingleOrDefaultAsync(m => m.ID == id);
            if (leadNote == null)
            {
                return NotFound();
            }
            return View(leadNote);
        }

        // POST: crm/LeadNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] LeadNote leadNote)
        {
            if (id != leadNote.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadNoteExists(leadNote.ID))
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
            return View(leadNote);
        }

        // GET: crm/LeadNotes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadNote = await _context.LeadNote
                .SingleOrDefaultAsync(m => m.ID == id);
            if (leadNote == null)
            {
                return NotFound();
            }

            return View(leadNote);
        }

        // POST: crm/LeadNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var leadNote = await _context.LeadNote.SingleOrDefaultAsync(m => m.ID == id);
            _context.LeadNote.Remove(leadNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadNoteExists(Guid id)
        {
            return _context.LeadNote.Any(e => e.ID == id);
        }
    }
}
