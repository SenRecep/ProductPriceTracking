using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using ProductPriceTracking.Core.Entities.Concrete;

namespace ProductPriceTracking.Entities.ExtensionMethods
{
  public static  class EntityDataTransfer
    {
        public static void DataTransfer(object left, object right)
        {
            Type leftType = left.GetType();
            Type rightType = right.GetType();
            PropertyInfo[] rightProperties = rightType.GetProperties();
            PropertyInfo[] leftProperties = leftType.GetProperties();
            rightProperties.ToList().ForEach((r) =>
            {
                if (!r.Name.Equals(nameof(EntityBase.Id)))
                {
                    PropertyInfo l = leftProperties.FirstOrDefault(x => x.Name.Equals(r.Name));
                    if (l != null)
                        if (l.GetType().Equals(r.GetType()))
                            l.SetValue(left, r.GetValue(right));
                }

            });
        }
    }
}
