using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model;
using shopyway.Model.Men;

namespace shopyway.Implements
{
    public class Men_section_ : IMen_section
    {
        private readonly DataContext db;
        public Men_section_(DataContext db)
        {
            this.db = db;
        }

        public dynamic men_section_data()
        {
          
            dynamic path = $"D:\\Data\\Men\\";
           
            var rand = new Random();
            var files = Directory.GetFiles(path, "*.json");
          
            List<dynamic> Mster_list = new List<dynamic>();
            List<ajio> product_list = new List<ajio>();
            List<ajio> special_list = new List<ajio>();
            List<Men_section> special_list_category = new List<Men_section>();
            List<Men_section> trending_list = new List<Men_section>();

            for (int i = 0; i< 10 ; i++)
            {

                var dam = files[rand.Next(files.Length)];
                var json_data = File.ReadAllText(dam);
                var json = JsonConvert.DeserializeObject<ajio>(json_data);
                product_list.Add(json);
                
                
               

            }
            for (int i = 0; i < 2 ; i++)
            {
                var dam = files[rand.Next(files.Length)];
                var json_data = File.ReadAllText(dam);
                var json = JsonConvert.DeserializeObject<ajio>(json_data);
                special_list.Add(json);

            }
            for (int i = 0; i < 3; i++)
            {
                Men_section m = new Men_section();

                var dam = files[rand.Next(files.Length)];
                var json_data = File.ReadAllText(dam);
                var json = JsonConvert.DeserializeObject<ajio>(json_data);

                m.File_name = json.URL_image;
                m.Product_name = json.product_name;
                m.category = json.Type;

                special_list_category.Add(m);
               

            }

            for (int i = 0; i < 4; i++)
            {
                Men_section m = new Men_section();


                var dam = files[rand.Next(files.Length)];
                var json_data = File.ReadAllText(dam);
                var json = JsonConvert.DeserializeObject<ajio>(json_data);

                m.File_name = json.URL_image;
                m.Product_name = json.product_name;
                m.category = json.Type;

                trending_list.Add(m);
             

            }
            Mster_list.Add(product_list);
            Mster_list.Add(special_list);
            Mster_list.Add(special_list_category);
            Mster_list.Add(trending_list);

            return Mster_list;



        }
    }
}
