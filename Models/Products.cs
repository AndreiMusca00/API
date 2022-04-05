using System;

namespace API.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] Ratings { get; set; }
        public DateTime CreatedOn { get; set; }

        public Products( string name,string description,int[] ratings)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Ratings = ratings;
            CreatedOn=DateTime.Now;
        }
    }
}
