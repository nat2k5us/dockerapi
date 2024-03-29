﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteApi.Repositories;

namespace QuoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {

        private IQuoteRepository quoteRepository;

        public QuotesController(IQuoteRepository repo)
        {
            this.quoteRepository = repo;
         
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allQuotes = new List<Quote.DataAccess.Models.Quote>();
            try
            {
                allQuotes = await quoteRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return this.Ok(allQuotes);            
        }

        [HttpGet]
        [Route("{symbol}")]
        public async Task<IActionResult> Get(string symbol)
        {
            var quote = new Quote.DataAccess.Models.Quote();
            try
            {
                quote = await quoteRepository.Get(symbol);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return this.Ok(quote);
        }

     // GET api/values/5
     //   [HttpGet("{id}")]
     //   public ActionResult<string> Get(int id)
     //   {
     //       return "value";
     //   }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
