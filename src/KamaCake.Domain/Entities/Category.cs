using KamaCake.Domain.Common;

namespace KamaCake.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

    }
}
