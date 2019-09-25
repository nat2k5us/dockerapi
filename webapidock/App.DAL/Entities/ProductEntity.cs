using System;

namespace App.DAL.Entities
{
    public class ProductEntity
    {
        public ProductEntity(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}