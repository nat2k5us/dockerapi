using System;
namespace Quote.DataAccess.DbLayers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Quote.DataAccess.Models;

    public interface IDbInitializer
    {
        Task SeedAsync();
    }

    public class DbInitializer : IDbInitializer
    {

        private readonly QuoteDbContext context;

        public DbInitializer(QuoteDbContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.MigrateAsync().ConfigureAwait(false);
                       
            if (!await this.context.Quotes.AnyAsync())
            {
                Quote item1 = new Quote
                {
                    Symbol = "MSFT",
                    Description = "Microsoft Corporation",
                    Price = 130.12,
                    LastAccessed = new DateTime(2018, 2, 1)
                };

                Quote item2 = new Quote
                {
                    Symbol = "AMZN",
                    Description = "Amazon Corporation",
                    Price = 130.12,
                    LastAccessed = new DateTime(2018, 2, 1)
                };
                Quote item3 = new Quote
                {
                    Symbol = "GOOG",
                    Description = "Google Inc",
                    Price = 130.12,
                    LastAccessed = new DateTime(2018, 2, 1)
                };

                Quote item4 = new Quote
                {
                    Symbol = "LYFT",
                    Description = "Lyft Corporation",
                    Price = 130.12,
                    LastAccessed = new DateTime(2018, 2, 1)
                };
                Quote item5 = new Quote
                {
                    Symbol = "UBER",
                    Description = "Uber Corporation",
                    Price = 130.12,
                    LastAccessed = new DateTime(2018, 2, 1)
                };


                this.context.Quotes.Add(item1);
                this.context.Quotes.Add(item2);
                this.context.Quotes.Add(item3);
                this.context.Quotes.Add(item4);
                this.context.Quotes.Add(item5);
                

                await this.context.SaveChangesAsync();
            }

           
        }
    }
}