using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace shopyway.Function
{
    public class isEmpty
    {
        public static bool IsNull(JObject T)
        {
            return T == null ? true : false;
        }
    }
}
