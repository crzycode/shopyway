using System.ComponentModel.DataAnnotations;

namespace shopyway.Model.Electronics
{
    public class Electronics_product_category
    {
        [Key]
        public int El_Category_id { get; set; }
        public string id { get; set; }
       
        public string type { get; set; }
    }
}
