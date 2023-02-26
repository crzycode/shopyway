using System.ComponentModel.DataAnnotations;

namespace shopyway.Model.Topdeals
{
    public class TopElec_products
    {
        [Key]
        public int Product_id { get; set; }
        public string u_id { get; set; }
        public string Product_name { get; set; }
        public string type { get; set; }
        public double offer_price { get; set; }
        public double original_price { get; set; }
        public string off_now { get; set; }
        public int total_rating { get; set; }
        public int total_reviews { get; set; }
        public double rating { get; set; }
        public string description { get; set; }
    }
}
