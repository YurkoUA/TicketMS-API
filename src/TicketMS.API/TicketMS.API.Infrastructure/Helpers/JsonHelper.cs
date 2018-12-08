using Newtonsoft.Json;

namespace TicketMS.API.Infrastructure.Helpers
{
    public class JsonHelper
    {
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string SerializeAsArray(params object[] values)
        {
            return JsonConvert.SerializeObject(values);
        }
    }
}
