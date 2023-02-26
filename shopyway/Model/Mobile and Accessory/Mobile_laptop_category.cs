using System.ComponentModel.DataAnnotations;

namespace shopyway.Model.Mobile_and_Accessory
{
    public class Mobile_laptop_category
    {
        [Key]
        public int El_Category_id { get; set; }
        public string id { get; set; }

        public string type { get; set; }
    }
}
