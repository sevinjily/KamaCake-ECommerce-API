using KamaCake.Domain.Common;
using KamaCake.Domain.Enums;

namespace KamaCake.Domain.Entities
{
    public class CartItem:BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Size { get; set; }
        public CakeColor? Color { get; set; } //enum

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        public Guid CakeId { get; set; }
        public Cake Cake { get; set; }
    }
}
