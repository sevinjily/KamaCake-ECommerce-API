namespace KamaCake.Application.DTOs.CakeDTOs
{
    public class CreateCakeDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; } // optional
        public string? ImageUrl { get; set; } 
        public Guid CategoryId { get; set; }
    }
}
