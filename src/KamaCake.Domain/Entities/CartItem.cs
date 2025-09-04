using KamaCake.Domain.Common;

namespace KamaCake.Domain.Entities
{
    public class CartItem:BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Cart Cart { get; set; }
        public Guid CartId { get; set; }
        public Cake Cake { get; set; }
        public Guid CakeId { get; set; }
    }
}
