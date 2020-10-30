using Microsoft.VisualBasic.CompilerServices;
using ProductPriceTracking.Core.Entities.Interfaces;
using System;
using System.Runtime.CompilerServices;

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
