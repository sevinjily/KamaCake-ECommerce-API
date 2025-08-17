﻿using KamaCake.Domain.Common;

namespace KamaCake.Domain.Entities
{
    public class Cake:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

       
    }
}
