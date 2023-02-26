using System.ComponentModel.DataAnnotations;

namespace shopyway.Model.Fashion
{
    public class Fashion_category
    {
        [Key]
        public int fashion_cat_id { get; set; }
        public string image_name { get; set; }
        public string type { get; set; }
    }
}
