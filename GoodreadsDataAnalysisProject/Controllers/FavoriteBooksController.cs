using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodreadsDataAnalysis.Data;
using GoodreadsDataAnalysis.Models;
using Microsoft.AspNetCore.Authorization;

namespace GoodreadsDataAnalysis.Controllers
{
    public class FavoriteBooksController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FavoriteBooksController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
              //list of all book results
              return _context.FavoriteBooks != null ? 
                          View(await _context.FavoriteBooks.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.Book'  is null.");
        }
        // GET: Books/ShowSeachForm
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        // POST: Books/ShowSeachResults
        // parameter names need to match the input name from the specified view
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            //list of filtered book results
            return _context.FavoriteBooks != null ?
                          View("Index", await _context.FavoriteBooks.Where(
                                b => b.Title.Contains(SearchPhrase) || 
                                b.Genre.Contains(SearchPhrase) || 
                                b.Author.Contains(SearchPhrase)).ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.FavoriteBook'  is null.");
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FavoriteBooks == null)
            {
                return NotFound();
            }

            var book = await _context.FavoriteBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Genre")] FavoriteBook book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FavoriteBooks == null)
            {
                return NotFound();
            }

            var book = await _context.FavoriteBooks.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Genre")] FavoriteBook book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FavoriteBooks == null)
            {
                return NotFound();
            }

            var book = await _context.FavoriteBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FavoriteBooks == null)
            {
                return Problem("Entity set 'ApplicationDBContext.FavoriteBook'  is null.");
            }
            var book = await _context.FavoriteBooks.FindAsync(id);
            if (book != null)
            {
                _context.FavoriteBooks.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.FavoriteBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
