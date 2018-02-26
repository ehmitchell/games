using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;
using GAMES.Data;

namespace GAMES.Controllers
{
    public class PersonScoresController : Controller
    {
        private readonly GamesContext _context;

        public PersonScoresController(GamesContext context)
        {
            _context = context;
        }

        // GET: PersonScores
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonScores.ToListAsync());
        }

        // GET: PersonScores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personScore = await _context.PersonScores
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personScore == null)
            {
                return NotFound();
            }

            return View(personScore);
        }

        // GET: PersonScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Score")] PersonScore personScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personScore);
        }

        // GET: PersonScores/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personScore = await _context.PersonScores.SingleOrDefaultAsync(m => m.ID == id);
            if (personScore == null)
            {
                return NotFound();
            }
            return View(personScore);
        }

        // POST: PersonScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Score")] PersonScore personScore)
        {
            if (id != personScore.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonScoreExists(personScore.ID))
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
            return View(personScore);
        }

        // GET: PersonScores/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personScore = await _context.PersonScores
                .SingleOrDefaultAsync(m => m.ID == id);
            if (personScore == null)
            {
                return NotFound();
            }

            return View(personScore);
        }

        // POST: PersonScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personScore = await _context.PersonScores.SingleOrDefaultAsync(m => m.ID == id);
            _context.PersonScores.Remove(personScore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonScoreExists(int id)
        {
            return _context.PersonScores.Any(e => e.ID == id);
        }
    }
}
