using GoodreadsDataAnalysis.Data;
using GoodreadsDataAnalysis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodreadsBookAnalysis.Controllers
{
    public class GoodreadsAnalysisController : Controller
    {

        private readonly BooksDBContext _context;
        public GoodreadsAnalysisController(BooksDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var topBooks5Star = _context.GoodreadsBooks
            .OrderByDescending(book => book.Ratings5)
            .Take(5)
            .Select(book => new GoodreadsBook
            {
                OriginalTitle = book.OriginalTitle,
                Authors = book.Authors,
                //AverageRating = book.AverageRating,
                //CountOf5StarRatings = book.Ratings5
            }).ToListAsync();

            return View("Index", await topBooks5Star);
        }
    }
}
