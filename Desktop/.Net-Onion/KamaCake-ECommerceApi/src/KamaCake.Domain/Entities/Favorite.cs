using KamaCake.Domain.Common;

namespace KamaCake.Domain.Entities
{
    public class Favorite:BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ProductId { get; set; }
        public Cake Product { get; set; }
    }
}
