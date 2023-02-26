
using System.ComponentModel.DataAnnotations;

namespace shopyway.Model
{
    public class Partner_user
    {
        [Key]
        public int partner_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public string gst { get; set; }
        public string password { get; set; }
        public string site { get; set; }
    }
}
