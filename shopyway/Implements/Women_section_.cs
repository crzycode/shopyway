using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model;
using shopyway.Model.Women;

namespace shopyway.Implements
{
    public class Women_section_ : IWomen_section
    {
        private readonly DataContext db;
        public Women_section_(DataContext db)
        {
            this.db = db;
        }

        public dynamic women_section_data()
        {
          
            List<dynamic> Mster_list = new List<dynamic>();
            List<ajio> product_list = new List<ajio>();
            List<ajio> special_list = new List<ajio>();
            List<Women_section> special_list_category = new List<Women_section>();
            List<Women_section> trending_list = new List<Women_section>();

            dynamic path = $"D:\\Data\\Women\\";

            var rand = new Random();
            var files = Directory.GetFiles(path, "*.json");

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
                Women_section m = new Women_section();

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
                Women_section m = new Women_section();

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

