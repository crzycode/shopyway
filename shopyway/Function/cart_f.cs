using System.ComponentModel.DataAnnotations;

namespace shopyway.Function
{
    public class cart_f
    {
        [Key]
        public int Cart_id { get; set; }
        public int User_id { get; set; }
        public string Product_id { get; set; }
        public string Product_data { get; set; }
        public int count { get; set;}
    }
}
