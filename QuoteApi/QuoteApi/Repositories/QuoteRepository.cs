using System;
namespace QuoteApi.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Quote.DataAccess.DbLayers;
    using Quote.DataAccess.Models;
    using Quote.DataAccess.Repositories;

    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        private QuoteDbContext AppContext => (QuoteDbContext)this._context;

        public QuoteRepository(QuoteDbContext context) : base(context)
        {

        }
        public Task<bool> Create(Quote item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Quote>> GetAll()
        {
            return this.AppContext.Quotes.ToListAsync();

        }

        public async Task<Quote> Get(int id)
        {
            return await this.AppContext.Quotes.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Quote> Get(string id)
        {
            return await this.AppContext.Quotes.Where(c => c.Symbol == id).FirstOrDefaultAsync();
        }
    }
}
