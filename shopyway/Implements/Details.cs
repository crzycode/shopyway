using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;

namespace shopyway.Implements
{
    public class Details : IDetails
    {
        
        private readonly DataContext db;
        public Details(DataContext db)
        {
            this.db = db;
        }

        public dynamic get_details(string id)
        {
           List<dynamic> details = new List<dynamic>();
                string[] which_id = id.Split('-');
                if (which_id.Length > 1)
                {
                    int file = Convert.ToInt32(which_id[1]);
                    if (file <= 155638)
                    {
                        var json_data = File.ReadAllText($"D:\\Data\\Men\\{id}.json");
                        var json = JsonConvert.DeserializeObject<ajio>(json_data);
                    
                        details.Add(json);

                    }
                    else
                    {
                        var json_data = File.ReadAllText($"D:\\Data\\Women\\{id}.json");
                        var json = JsonConvert.DeserializeObject<ajio>(json_data);
                  
                    details.Add(json);

                    }
                }
                else
                {
                    var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{id}.json");
                    var json = JsonConvert.DeserializeObject<Electronics>(json_data);
               
                details.Add(json);
                }
            return details;
        }

        public dynamic get_add_data(string type)
        {
            dynamic path = $"D:\\Data\\{type}\\";
            List<dynamic> details = new List<dynamic>();
            var rand = new Random();
            var files = Directory.GetFiles(path, "*.json");
            if(type != "Electronics")
            {
                for (int i = 0; i < 1; i++)
                {
                    var dam = files[rand.Next(files.Length)];
                    var json_data = File.ReadAllText(dam);
                    var json = JsonConvert.DeserializeObject<ajio>(json_data);
                    /*var seri = JsonConvert.SerializeObject(json);*/
                    details.Add(json);
                }

                return details;
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    var dam = files[rand.Next(files.Length)];
                    var json_data = File.ReadAllText(dam);
                    var json = JsonConvert.DeserializeObject<Electronics>(json_data);
                    /*var seri = JsonConvert.SerializeObject(json);*/
                    details.Add(json);
                }

                return details;
            }
        

        }

       
        public dynamic get_elec_add_data(string id)
        {
         

            dynamic path = $"D:\\Data\\{id}\\";
            List<dynamic> details = new List<dynamic>();
            var rand = new Random();
            var files = Directory.GetFiles(path, "*.json");

            if(id != "Electronics")
            {
                for (int i = 0; i < 3; i++)
                {
                    var dam = files[rand.Next(files.Length)];
                    var json_data = File.ReadAllText(dam);
                    var json = JsonConvert.DeserializeObject<ajio>(json_data);
                    details.Add(json);
                }

                return details;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    var dam = files[rand.Next(files.Length)];
                    var json_data = File.ReadAllText(dam);
                    var json = JsonConvert.DeserializeObject<Electronics>(json_data);
                    details.Add(json);
                }

                return details;
            }
          

        }
    }
}
