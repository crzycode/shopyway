using System.ComponentModel.DataAnnotations;

namespace shopyway.Model.Mobile_and_Accessory
{
    public class Mobile_laptop_product
    {
        [Key]
        public int Product_id { get; set; }
        public string id { get; set; }
        public string Product_name { get; set; }
        public string type { get; set; }
    }
}
