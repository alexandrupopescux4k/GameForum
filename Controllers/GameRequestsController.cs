using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameForum.Data;
using GameForum.Models;
using GameForum.Services.Interfaces;

namespace GameForum.Controllers
{
    public class GameRequestsController : Controller
    {
        private readonly GameForumContext _context;
        private readonly IGameRequestService _gameRequestService;

        public GameRequestsController(GameForumContext context,IGameRequestService gameRequestService)
        {
            _context = context;
            _gameRequestService = gameRequestService;
        }

        // GET: GameRequests
        public async Task<IActionResult> Index()
        {
            var requests = _gameRequestService.GetAll();
            return View(requests);
        }

        // GET: GameRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameRequest = await _context.GameRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameRequest == null)
            {
                return NotFound();
            }

            return View(gameRequest);
        }

        // GET: GameRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImageUrl,RequestedByUserId,Status,RequestedAt")] GameRequest gameRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameRequest);
        }

        // GET: GameRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameRequest = await _context.GameRequests.FindAsync(id);
            if (gameRequest == null)
            {
                return NotFound();
            }
            return View(gameRequest);
        }

        // POST: GameRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ImageUrl,RequestedByUserId,Status,RequestedAt")] GameRequest gameRequest)
        {
            if (id != gameRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameRequestExists(gameRequest.Id))
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
            return View(gameRequest);
        }

        // GET: GameRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameRequest = await _context.GameRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameRequest == null)
            {
                return NotFound();
            }

            return View(gameRequest);
        }

        // POST: GameRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameRequest = await _context.GameRequests.FindAsync(id);
            if (gameRequest != null)
            {
                _context.GameRequests.Remove(gameRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameRequestExists(int id)
        {
            return _context.GameRequests.Any(e => e.Id == id);
        }
    }
}
