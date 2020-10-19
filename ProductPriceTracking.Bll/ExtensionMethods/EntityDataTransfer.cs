using ProductPriceTracking.Core.DTO.Interfaces;
using ProductPriceTracking.Core.Entities.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace ProductPriceTracking.Bll.ExtensionMethods
{
    public static class EntityDataTransfer
    {
        public static void Transfer(this IEntityBase entity, IDto dto) =>
            DataTransfer(entity, dto);

        public static void Transfer(this IDto dto, IEntityBase entity) =>
            DataTransfer(dto, entity);

        public static void Transfer(this IEntityBase entity, IEntityBase dto) =>
            DataTransfer(entity, dto);

        public static void Transfer(this IDto dto, IDto entity)=>
            DataTransfer(dto, entity);

        public static void DataTransfer(object left, object right)
        {
            Type leftType = left.GetType();
            Type rightType = right.GetType();
            PropertyInfo[] rightProperties = rightType.GetProperties();
            PropertyInfo[] leftProperties = leftType.GetProperties();
            rightProperties.ToList().ForEach((r) =>
            {
                PropertyInfo l = leftProperties.FirstOrDefault(x => x.Name.Equals(r.Name));
                if (l != null)
                    if (l.GetType().Equals(r.GetType()))
                        l.SetValue(left, r.GetValue(right));
            });
        }
    }
}
