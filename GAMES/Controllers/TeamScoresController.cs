using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;

namespace GAMES.Controllers
{
    public class TeamScoresController : Controller
    {
        private readonly GamesContext _context;

        public TeamScoresController(GamesContext context)
        {
            _context = context;
        }

        // GET: TeamScores
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamScore.ToListAsync());
        }

        // GET: TeamScores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamScore = await _context.TeamScore
                .SingleOrDefaultAsync(m => m.ID == id);
            if (teamScore == null)
            {
                return NotFound();
            }

            return View(teamScore);
        }

        // GET: TeamScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Score")] TeamScore teamScore)
        {
            if (ModelState.IsValid)
            {
                teamScore.ID = Guid.NewGuid();
                _context.Add(teamScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamScore);
        }

        // GET: TeamScores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamScore = await _context.TeamScore.SingleOrDefaultAsync(m => m.ID == id);
            if (teamScore == null)
            {
                return NotFound();
            }
            return View(teamScore);
        }

        // POST: TeamScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Score")] TeamScore teamScore)
        {
            if (id != teamScore.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamScoreExists(teamScore.ID))
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
            return View(teamScore);
        }

        // GET: TeamScores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamScore = await _context.TeamScore
                .SingleOrDefaultAsync(m => m.ID == id);
            if (teamScore == null)
            {
                return NotFound();
            }

            return View(teamScore);
        }

        // POST: TeamScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var teamScore = await _context.TeamScore.SingleOrDefaultAsync(m => m.ID == id);
            _context.TeamScore.Remove(teamScore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamScoreExists(Guid id)
        {
            return _context.TeamScore.Any(e => e.ID == id);
        }
    }
}
