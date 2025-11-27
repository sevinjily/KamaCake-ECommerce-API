namespace KamaCake.Domain.Common
{
    public class BaseEntity:IEntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime UpdateDate { get; set; }
        //public bool? IsDeleted { get; set; }
        //public DateTime? DeletedDate { get; set; }
    }
}
