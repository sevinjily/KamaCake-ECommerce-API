using KamaCake.Domain.Enums;
using System.ComponentModel;

namespace KamaCake.Application.DTOs.CartDTOs.CartItemDTO
{
    public class CreateCartItemDTO
    {
        public Guid CakeId { get; init; }
        [DefaultValue(1)]
        public int Quantity { get; init; } = 1;
        public CakeColor? Color { get; init; }
        public string? Size { get; init; } = "1.5kq";
     
    }
}
