using KamaCake.Domain.Enums;

namespace KamaCake.Application.DTOs.CartDTOs.CartItemDTO
{
    public class CreateCartItemDTO
    {
        public Guid CakeId { get; init; }
        public int Quantity { get; init; }
        public CakeColor? Color { get; init; }
        public string? Size { get; init; }
     
    }
}
