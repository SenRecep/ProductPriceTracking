
using ProductPriceTracking.Core.DTO.Interfaces;
using ProductPriceTracking.Core.Entities.Interfaces;


namespace ProductPriceTracking.Bll.ExtensionMethods
{
    public static class EntityDataTransfer
    {
        public static void Transfer(this IEntityBase entity, IDto dto)
        {
            Entities.ExtensionMethods.EntityDataTransfer.DataTransfer(entity, dto);
        }

        public static void Transfer(this IDto dto, IEntityBase entity)
        {
            Entities.ExtensionMethods.EntityDataTransfer.DataTransfer(dto, entity);
        }

        public static void Transfer(this IEntityBase entity, IEntityBase dto)
        {
            Entities.ExtensionMethods.EntityDataTransfer.DataTransfer(entity, dto);
        }

        public static void Transfer(this IDto dto, IDto entity)
        {
            Entities.ExtensionMethods.EntityDataTransfer.DataTransfer(dto, entity);
        }
    }
}
