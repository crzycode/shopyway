using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model.Electronics;
using shopyway.Model.Men;
using shopyway.Model.Mobile_and_Accessory;

namespace shopyway.Implements
{
    public class Electronic_product_category_ : IElectronic_category_product
    {
        private readonly DataContext db;
        public Electronic_product_category_(DataContext db)
        {
            this.db = db;
        }

        public dynamic get_Electronic_product_category()
        {
            List<dynamic> Master_list = new List<dynamic>();
            List<Electronics_product_category> category = new List<Electronics_product_category>();
            List<Electronics> product_list = new List<Electronics>();

            List<Electronics> advertise_list = new List<Electronics>();

            List<Electronics> save_list = new List<Electronics>();
            List<Electronics> banner_list = new List<Electronics>();


            var data1 = db.Electronics_product_category.FromSqlRaw("SELECT * FROM Electronics_product_category").ToList();

           
            int count = 0;
            

            for (int i = 0; i < data1.Count; i++)
            {

                category.Add(data1[i]);

            }

            var data = db.Mobile_accessory_product.FromSqlRaw("select top 14 * from Electronic_products ORDER BY NEWID()").ToList();
            for (int i = 0; i < 10; i++)
            {
                var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{data[count].id}.json");
                var json = JsonConvert.DeserializeObject<Electronics>(json_data);
                product_list.Add(json);

                count++;
            }
            for (int i = 0; i < 2; i++)
            {
                var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{data[count].id}.json");
                var json = JsonConvert.DeserializeObject<Electronics>(json_data);
                advertise_list.Add(json);
                count++;

            }

            for (int i = 0; i < 1; i++)
            {
                var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{data[count].id}.json");
                var json = JsonConvert.DeserializeObject<Electronics>(json_data);
                save_list.Add(json);
                
                count++;

            }
            for (int i = 0; i < 1; i++)
            {
                var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{data[count].id}.json");
                var json = JsonConvert.DeserializeObject<Electronics>(json_data);
                banner_list.Add(json);
                count++;

            }
            Master_list.Add(category);
            Master_list.Add(product_list);
            Master_list.Add(advertise_list);
            Master_list.Add(save_list);
            Master_list.Add(banner_list);

            return Master_list;
        }

       
    }
}
