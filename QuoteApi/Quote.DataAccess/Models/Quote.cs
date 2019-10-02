using System;
using System.Text;

namespace Quote.DataAccess.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime LastAccessed { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (System.Reflection.PropertyInfo property in this.GetType().GetProperties())
            {
                sb.Append(property.Name);
                sb.Append(": ");
                if (property.GetIndexParameters().Length > 0)
                {
                    sb.Append("Indexed Property cannot be used");
                }
                else
                {
                    sb.Append(property.GetValue(this, null));
                }

                sb.Append(System.Environment.NewLine);
            }

            return sb.ToString();

        }
    }
    
}
