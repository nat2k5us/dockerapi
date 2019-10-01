using System;
namespace Quote.DataAccess.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime LastAccessed { get; set; }

    }
    
}
