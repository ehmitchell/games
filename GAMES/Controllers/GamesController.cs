using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GAMES.Models;
using GAMES.Data;
using GAMES.Service;
using System.Net;

namespace GAMES.Controllers
{
    public class GamesController : Controller
    {
        private readonly GamesContext _context;
        private readonly GamesInstanceService _gamesInstanceService;
        private readonly TeamService _teamService;


        public GamesController(GamesContext context,
            GamesInstanceService gamesInstanceService,
            TeamService teamService)
        {
            _context = context;
            _gamesInstanceService = gamesInstanceService;
            _teamService = teamService;
        }


        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }

        public IActionResult GamesInstanceIndex()
        {
            return View( _gamesInstanceService.GetAllGames());
        }

        
        public IActionResult CreateGamesInstance()
        {
            return View(new GamesInstance());
        }

        [HttpPost]
        public IActionResult CreateGamesInstance(GamesInstance gamesInstance)
        {
            _gamesInstanceService.CreateGamesInstance(gamesInstance);
            return RedirectToAction("GamesInstanceIndex");
        }

        [HttpPost]
        public IActionResult GenerateInstanceTeams(int gamesInstanceId)
        {
            if (_gamesInstanceService.Get(gamesInstanceId).IsActive)
            {
                List<Team> teams = _teamService.GenerateRandomTeams(gamesInstanceId);
                return new StatusCodeResult((int)HttpStatusCode.OK);
            }
            
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }

        // GET: Games/Details/5
        public IActionResult Details(int id)
        {
            var game =  _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Rules,IsTeamScore,GameType,GameScoreOrder")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.SingleOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Rules,IsTeamScore,GameType,GameScoreOrder")] Game game)
        {
            if (id != game.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.ID))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .SingleOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.ID == id);
        }
    }
}
