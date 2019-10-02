namespace QuoteApi.Repositories
{

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Quote.DataAccess.Models;
    using Quote.DataAccess.Repositories;

    public interface IQuoteRepository : IRepository<Quote>
    {

        Task<Quote> Get(int id);

        Task<List<Quote>> GetAll();


        Task<bool> Create(Quote item);


        Task<bool> Delete(int id);
    }
}