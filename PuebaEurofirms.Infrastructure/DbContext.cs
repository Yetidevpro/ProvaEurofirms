using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaEurofirms.Domain.Models;

namespace PruebaEurofirms.Infrastructure
{
    public class CharacterDbContext : DbContext
    {
        public CharacterDbContext(DbContextOptions<CharacterDbContext> options)
            : base(options) { }

        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<List<string>, string>(
                v => string.Join(",", v),
                v => string.IsNullOrEmpty(v)
                    ? new List<string>()
                    : v.Split(new[] { ',' }, StringSplitOptions.None).ToList()
            );

            modelBuilder.Entity<Character>()
                .Property(c => c.Episodes)
                .HasConversion(converter);
        }

    }
}
