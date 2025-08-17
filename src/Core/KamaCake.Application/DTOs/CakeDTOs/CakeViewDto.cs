﻿namespace KamaCake.Application.DTOs.CakeDTOs
{
    public class CakeViewDto //frontend ucun
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty; // CategoryId əvəzinə
    }
}
