using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CommsRoomInvent.Data;
using CommsRoomInvent.Models.DataModels;

namespace CommsRoomInvent.Controllers
{
    public class CRoomReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CRoomReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CRoomReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CRoomReport
                .Include(c => c.PreformedBy)
                .Include(c => c.Rating)
                .Include(c => c.ReportStatus)
                .Include(c => c.Site);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CRoomReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRoomReport = await _context.CRoomReport
                .Include(c => c.PreformedBy)
                .Include(c => c.Rating)
                .Include(c => c.ReportStatus)
                .Include(c => c.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cRoomReport == null)
            {
                return NotFound();
            }

            return View(cRoomReport);
        }

        // GET: CRoomReports/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "RatingName");
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName");
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "SitName");
            return View();
        }

        // POST: CRoomReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportStatusId,SiteId,RatingId,PersonId,DateTimeScheduled,DateTimeStarted,DateTimeEnded,NumberOfFloors,NumberOfCRs,Description,SpecialConsiderations")] CRoomReport cRoomReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cRoomReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", cRoomReport.PersonId);
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "RatingName", cRoomReport.RatingId);
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName", cRoomReport.ReportStatusId);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "SiteName", cRoomReport.SiteId);
            return View(cRoomReport);
        }

        // GET: CRoomReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRoomReport = await _context.CRoomReport.FindAsync(id);
            if (cRoomReport == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", cRoomReport.PersonId);
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "RatingName", cRoomReport.RatingId);
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName", cRoomReport.ReportStatusId);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "SiteName", cRoomReport.SiteId);
            return View(cRoomReport);
        }

        // POST: CRoomReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportStatusId,SiteId,RatingId,PersonId,DateTimeScheduled,DateTimeStarted,DateTimeEnded,NumberOfFloors,NumberOfCRs,Description,SpecialConsiderations")] CRoomReport cRoomReport)
        {
            if (id != cRoomReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cRoomReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CRoomReportExists(cRoomReport.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", cRoomReport.PersonId);
            ViewData["RatingId"] = new SelectList(_context.Set<Rating>(), "Id", "RatingName", cRoomReport.RatingId);
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName", cRoomReport.ReportStatusId);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "SiteName", cRoomReport.SiteId);
            return View(cRoomReport);
        }

        // GET: CRoomReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRoomReport = await _context.CRoomReport
                .Include(c => c.PreformedBy)
                .Include(c => c.Rating)
                .Include(c => c.ReportStatus)
                .Include(c => c.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cRoomReport == null)
            {
                return NotFound();
            }

            return View(cRoomReport);
        }

        // POST: CRoomReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cRoomReport = await _context.CRoomReport.FindAsync(id);
            _context.CRoomReport.Remove(cRoomReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CRoomReportExists(int id)
        {
            return _context.CRoomReport.Any(e => e.Id == id);
        }
    }
}
