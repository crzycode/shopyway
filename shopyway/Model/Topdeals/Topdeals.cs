using System.ComponentModel.DataAnnotations;

namespace shopyway.Model.Topdeals
{
    public class Topdeals
    {
        [Key]
        public int Deal_id { get; set; }
        public string Category_name { get; set; }
        public string Category_image { get; set; }
        public string Deal_type { get; set; }
    }
}
