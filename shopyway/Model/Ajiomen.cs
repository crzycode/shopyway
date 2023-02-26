using System.ComponentModel.DataAnnotations;

namespace shopyway.Model
{
    public class Ajiomen
    {
        [Key]
        public int Ajio_id { get; set; }

        public string File_name { get; set; }
        public string Product_name { get; set; }
        public string category { get; set; }
       
    }
}
