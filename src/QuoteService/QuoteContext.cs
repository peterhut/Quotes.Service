namespace QuoteService
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.IO;

    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options)
            : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Quote>()
                   .HasData(LoadSeedData());
        }

        private Quote[] LoadSeedData()
        {
            var result = new List<Quote>();
            var id = 1;
            using (var reader = new StreamReader(@"SeedData/randomquotes.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    result.Add(new Quote()
                    {
                        Id = id++,
                        Text = values[0],
                        Attribution = values[1]
                    });
                }
            }
            return result.ToArray();
        }
    }
}
