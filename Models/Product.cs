using System;

namespace API.Models
{
    public class Product
    {
        public Product(string name, string description, int[] ratings)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Ratings = ratings;
            CreatedOn = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }
        public DateTime CreatedOn { get; set; }


    }
}