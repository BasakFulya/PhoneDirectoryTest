using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PersonService.Entities
{
    public class PersonDbContext:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=PhoneGuide;User Id=postgres;Password=12345;");
        }
    }
}
