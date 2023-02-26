using System.ComponentModel.DataAnnotations;

namespace shopyway.Model.Topdeals
{
    public class TopElec_category
    {
        [Key]
        public int category_id { get; set; }
        public string image_name { get; set; }
        public string type { get; set; }
    }
}
