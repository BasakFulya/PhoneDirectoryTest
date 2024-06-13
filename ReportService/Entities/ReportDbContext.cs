using Microsoft.EntityFrameworkCore;

namespace ReportService.Entities
{
    public class ReportDbContext:DbContext
    {
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=PhoneGuide;User Id=postgres;Password=12345;");
        }
    }
}
