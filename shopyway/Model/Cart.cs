using System.ComponentModel.DataAnnotations;

namespace shopyway.Model
{
    public class Cart
    {
        [Key]
        public int Cart_id { get; set; }
        public int User_id { get; set; }
        public string Product_data { get; set; }
    }
}
