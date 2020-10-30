using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ProductPriceTracking.MvcUi.ExtensionMethods
{
    public static class ModelStateExtensionMethods
    {
        public static string GetErrorsString(this ModelStateDictionary modelState, bool html = true)
        {
            string separator = html ? "<br/>" : "\n";
            return string.Join(separator, modelState.Values.Select(x => x.Errors.Select(a => a.ErrorMessage)));
        }
    }
}
