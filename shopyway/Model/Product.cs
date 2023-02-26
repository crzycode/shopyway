using System.ComponentModel.DataAnnotations;

namespace shopyway.Model
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
        public string id { get; set; }
        public string Product_name { get; set; }
        public string category { get; set; }

        
     
    }
}
