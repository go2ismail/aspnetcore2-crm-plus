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
    public class SalesChannelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesChannelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: crm/SalesChannels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesChannel.ToListAsync());
        }

        // GET: crm/SalesChannels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesChannel = await _context.SalesChannel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salesChannel == null)
            {
                return NotFound();
            }

            return View(salesChannel);
        }

        // GET: crm/SalesChannels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: crm/SalesChannels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreatedDateUtc,IsActive,Name,Description")] SalesChannel salesChannel)
        {
            if (ModelState.IsValid)
            {
                salesChannel.ID = Guid.NewGuid();
                _context.Add(salesChannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesChannel);
        }

        // GET: crm/SalesChannels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesChannel = await _context.SalesChannel.SingleOrDefaultAsync(m => m.ID == id);
            if (salesChannel == null)
            {
                return NotFound();
            }
            return View(salesChannel);
        }

        // POST: crm/SalesChannels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CreatedDateUtc,IsActive,Name,Description")] SalesChannel salesChannel)
        {
            if (id != salesChannel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesChannel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesChannelExists(salesChannel.ID))
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
            return View(salesChannel);
        }

        // GET: crm/SalesChannels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesChannel = await _context.SalesChannel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salesChannel == null)
            {
                return NotFound();
            }

            return View(salesChannel);
        }

        // POST: crm/SalesChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var salesChannel = await _context.SalesChannel.SingleOrDefaultAsync(m => m.ID == id);
            _context.SalesChannel.Remove(salesChannel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesChannelExists(Guid id)
        {
            return _context.SalesChannel.Any(e => e.ID == id);
        }
    }
}
