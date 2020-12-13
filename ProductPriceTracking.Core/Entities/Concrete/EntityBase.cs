using System;

using ProductPriceTracking.Core.Entities.Interfaces;

namespace ProductPriceTracking.Core.Entities.Concrete
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
