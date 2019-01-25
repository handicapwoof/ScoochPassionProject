using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scooch.Interfaces;
using Scooch.Models;
using Scooch.Repositories;

namespace Scooch.Controllers
{
    public class ScoochController : Controller
    {
        private ScoochDBContext db;
        private IEventRepo repo;
        
        public ScoochController(ScoochDBContext db, IEventRepo repo)
        {
            this.db = db;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var events = db.EventEntity.ToList(); 

            return View(events);
        }

        public IActionResult Details(int id)
        {
            EventRepo eventRepo = new EventRepo(db);
            EventEntity e = eventRepo.Get(id);
            return View(e);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventEntity eventEntity)
        {
            if (ModelState.IsValid)
            {
                db.Add(eventEntity);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventEntity);
        }

        // GET: Technologies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var technology = await db.EventEntity
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        // POST: Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventEntity = await db.EventEntity.FindAsync(id);
            db.EventEntity.Remove(eventEntity);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}