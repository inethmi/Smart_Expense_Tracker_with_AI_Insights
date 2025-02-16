using Microsoft.EntityFrameworkCore;
using SmartExpenseTracker.API.Models;

namespace SmartExpenseTracker.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; } // Expenses Table
    }
}
