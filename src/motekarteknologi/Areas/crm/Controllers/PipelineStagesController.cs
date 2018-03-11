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
    public class PipelineStagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PipelineStagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/PipelineStages
        public async Task<IActionResult> Index()
        {
            return View(await _context.PipelineStage.ToListAsync());
        }

        // GET: crm/PipelineStages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipelineStage = await _context.PipelineStage
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pipelineStage == null)
            {
                return NotFound();
            }

            return View(pipelineStage);
        }

        // GET: crm/PipelineStages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/PipelineStages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] PipelineStage pipelineStage)
        {
            if (ModelState.IsValid)
            {
                pipelineStage.ID = Guid.NewGuid();
                _context.Add(pipelineStage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pipelineStage);
        }

        // GET: crm/PipelineStages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipelineStage = await _context.PipelineStage.SingleOrDefaultAsync(m => m.ID == id);
            if (pipelineStage == null)
            {
                return NotFound();
            }
            return View(pipelineStage);
        }

        // POST: crm/PipelineStages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] PipelineStage pipelineStage)
        {
            if (id != pipelineStage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pipelineStage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PipelineStageExists(pipelineStage.ID))
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
            return View(pipelineStage);
        }

        // GET: crm/PipelineStages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pipelineStage = await _context.PipelineStage
                .SingleOrDefaultAsync(m => m.ID == id);
            if (pipelineStage == null)
            {
                return NotFound();
            }

            return View(pipelineStage);
        }

        // POST: crm/PipelineStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pipelineStage = await _context.PipelineStage.SingleOrDefaultAsync(m => m.ID == id);
            _context.PipelineStage.Remove(pipelineStage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PipelineStageExists(Guid id)
        {
            return _context.PipelineStage.Any(e => e.ID == id);
        }
    }
}
