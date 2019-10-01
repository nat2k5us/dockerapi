using System;
namespace QuoteApi.Repositories
{
    using System.Threading.Tasks;
    using Quote.DataAccess.DbLayers;
    using Quote.DataAccess.Models;
    using Quote.DataAccess.Repositories;

    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
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

        public Task<Quote> Get(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
