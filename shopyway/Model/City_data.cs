using System.ComponentModel.DataAnnotations;

namespace shopyway.Model
{
    public class City_data
    {
        [Key]
        public int City_id { get; set; }
        public string PostOfficeName { get; set; }
        public int Pincode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
    }
}
