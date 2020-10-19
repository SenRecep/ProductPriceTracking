using System;

namespace ProductPriceTracking.Core.Entities.Interfaces
{
    public interface IEntityBase
    {
        int Id { get; set; }
        int CreateUserId { get; set; }
        DateTime CreateDate { get; set; }
        int? UpdateUserId { get; set; }
        DateTime? UpdateDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
