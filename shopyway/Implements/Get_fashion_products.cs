using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;

namespace shopyway.Implements
{
    public class Get_fashion_products : IGet_fashion_product
    {
        private readonly DataContext db;
        public Get_fashion_products(DataContext db)
        {
            this.db = db;
        }
        public dynamic get_fash_products()
        {
            var data = db.top_clothes.FromSqlRaw("SELECT TOP 10 * FROM top_clothes ORDER BY NEWID() ").ToList();
            List<ajio> products = new List<ajio>();
            foreach (var item in data)
            {
                string[] file_name = item.File_name.Split('-');
                int file_number = Convert.ToInt32(file_name[1]);
                if(file_number <= 155638)
                {
                    var json_data = File.ReadAllText($"D:\\Data\\Men\\{item.File_name}.json");
                    var json = JsonConvert.DeserializeObject<ajio>(json_data);
                    products.Add(json);
                }
                else
                {
                    var json_data = File.ReadAllText($"D:\\Data\\Women\\{item.File_name}.json");
                    var json = JsonConvert.DeserializeObject<ajio>(json_data);
                    products.Add(json);
                }
               
            }
            return products;
        }
    }
}
