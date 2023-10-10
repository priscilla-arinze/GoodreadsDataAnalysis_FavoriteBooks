using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GoodreadsDataAnalysis.Models;

namespace GoodreadsDataAnalysis.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<GoodreadsDataAnalysis.Models.FavoriteBook>? FavoriteBooks { get; set; }
    }
}