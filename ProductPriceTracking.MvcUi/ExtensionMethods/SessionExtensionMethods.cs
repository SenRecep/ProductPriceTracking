using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace ProductPriceTracking.MvcUi.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObj<T>(this ISession session, string key, T value) where T : class
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key, objectString);
        }
        public static T GetObj<T>(this ISession session, string key) where T : class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrWhiteSpace(objectString))
                return null;
            else
                return JsonConvert.DeserializeObject<T>(objectString);
        }
    }
}
