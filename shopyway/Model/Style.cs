using System.ComponentModel.DataAnnotations;

namespace shopyway.Model
{
    public class Style
    {
        public string id { get; set; }

        public string Brand { get; set; }
        public string Description { get; set; }
        public string URL_image { get; set; }
        public string Category_by_gender { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string product_name { get; set; }
        public int offer_price { get; set; }

        public int total_rating { get; set; }

        public int total_reviews { get; set; }
        public double rating { get; set; }
        public string Type { get; set; }
       



    }
}
