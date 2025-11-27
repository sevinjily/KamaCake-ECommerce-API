using KamaCake.Domain.Common;

namespace KamaCake.Domain.Entities
{
    public class Cart:BaseEntity
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}   
