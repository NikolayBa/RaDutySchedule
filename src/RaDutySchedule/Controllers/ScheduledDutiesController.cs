using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaDutySchedule.Data;

namespace RaDutySchedule.Models
{
    public class ScheduledDutiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduledDutiesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ScheduledDuties
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduledDuties.ToListAsync());
        }

        // GET: ScheduledDuties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledDuty = await _context.ScheduledDuties.SingleOrDefaultAsync(m => m.SchDutyID == id);
            if (scheduledDuty == null)
            {
                return NotFound();
            }

            return View(scheduledDuty);
        }

        // GET: ScheduledDuties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduledDuties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchDutyID,Day,EndTime,Name,StartTime")] ScheduledDuty scheduledDuty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduledDuty);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(scheduledDuty);
        }

        // GET: ScheduledDuties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledDuty = await _context.ScheduledDuties.SingleOrDefaultAsync(m => m.SchDutyID == id);
            if (scheduledDuty == null)
            {
                return NotFound();
            }
            return View(scheduledDuty);
        }

        // POST: ScheduledDuties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchDutyID,Day,EndTime,Name,StartTime")] ScheduledDuty scheduledDuty)
        {
            if (id != scheduledDuty.SchDutyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduledDuty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduledDutyExists(scheduledDuty.SchDutyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(scheduledDuty);
        }

        // GET: ScheduledDuties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduledDuty = await _context.ScheduledDuties.SingleOrDefaultAsync(m => m.SchDutyID == id);
            if (scheduledDuty == null)
            {
                return NotFound();
            }

            return View(scheduledDuty);
        }

        // POST: ScheduledDuties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduledDuty = await _context.ScheduledDuties.SingleOrDefaultAsync(m => m.SchDutyID == id);
            _context.ScheduledDuties.Remove(scheduledDuty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ScheduledDutyExists(int id)
        {
            return _context.ScheduledDuties.Any(e => e.SchDutyID == id);
        }
    }
}
