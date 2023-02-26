using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model;
using System.Text.RegularExpressions;

namespace shopyway.Implements
{
    public class Bulk_cart:IBulk_add_to_cart
    {
        private readonly DataContext db;
        private readonly ICart cart_data;
        public Bulk_cart(DataContext db, ICart _cart)
        {
            this.db = db;
            this.cart_data = _cart;
        }
        public dynamic bulk_add_cart(cart_f c)
        {
            double all_product_amount = 0;
            int all_product_count = 0;
            dynamic Product_obj = new JObject();
            List<dynamic> Total_list = new List<dynamic>();

            List<dynamic> new_Product_id = new List<dynamic>();
            List<dynamic> new_Count = new List<dynamic>();
            List<dynamic> new_Price = new List<dynamic>();

            List<dynamic> exist_Product_id = new List<dynamic>();
            List<dynamic> exist_Count = new List<dynamic>();
            List<dynamic> exist_Price = new List<dynamic>();
            int exist_all_product_amount = 0;
            int exist_all_product_count = 0;




            if (c.User_id == 0)
            {
               
                    dynamic des_product = JsonConvert.DeserializeObject<dynamic>(c.Product_data);

                    if (des_product.product.ContainsKey($"{c.Product_id}"))
                    {
                        string[] which_id = c.Product_id.Split('-');
                        if (which_id.Length > 1)
                        {
                            int file = Convert.ToInt32(which_id[1]);
                            if (file <= 155638)
                            {

                                var json_data = File.ReadAllText($"D:\\Data\\Men\\{c.Product_id}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                string P_id = des_product.product[$"{c.Product_id}"];
                                string[] split_count = P_id.Split('|');
                                int count = Convert.ToInt32(split_count[0]);
                                int amount = Convert.ToInt32(split_count[1]);

                            des_product.product[$"{c.Product_id}"] = Convert.ToString(c.count + "|" + amount);

                        }
                            else
                            {

                                var json_data = File.ReadAllText($"D:\\Data\\Women\\{c.Product_id}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                string P_id = des_product.product[$"{c.Product_id}"];
                                string[] split_count = P_id.Split('|');
                                int count = Convert.ToInt32(split_count[0]);
                                int amount = Convert.ToInt32(split_count[1]);
                            des_product.product[$"{c.Product_id}"] = Convert.ToString(c.count + "|" + amount);


                        }
                        }
                        else
                        {

                            var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{c.Product_id}.json");
                            var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                            string P_id = des_product.product[$"{c.Product_id}"];
                            string[] split_count = P_id.Split('|');
                            int count = Convert.ToInt32(split_count[0]);
                            int amount = Convert.ToInt32(split_count[1]);
                        des_product.product[$"{c.Product_id}"] = Convert.ToString(c.count + "|" + amount);

                    }




                    }
                 

                    var get_new_product = des_product.product;
                    var new_product = JsonConvert.SerializeObject(get_new_product);

                    string new_removableChars = Regex.Escape(@"}@{&'\\()\<>""#+");
                    string new_pattern = "[" + new_removableChars + "]";
                    string new_regex = Regex.Replace(new_product, new_pattern, "");
                    string[] new_product_split = new_regex.Split(',');

                    for (int i = 0; i < new_product_split.Length; i++)
                    {
                        string[] split_product = new_product_split[i].Split(new char[] { '|', ':' });

                        new_Product_id.Add(split_product[0]);
                        new_Count.Add(Convert.ToInt32(split_product[1]));
                        new_Price.Add(Convert.ToDouble(split_product[2]));
                    }
                    for (int i = 0; i < new_Product_id.Count; i++)
                    {
                        string[] which_id_loop = new_Product_id[i].Split('-');
                        if (which_id_loop.Length > 1)
                        {
                            int file = Convert.ToInt32(which_id_loop[1]);
                            if (file <= 155638)
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Men\\{new_Product_id[i]}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                int pp_count = Convert.ToInt32(new_Count[i]);
                                int pp_amount = json_.offer_price * pp_count;


                                all_product_amount = all_product_amount + pp_amount;
                                all_product_count = all_product_count + pp_count;
                                des_product.product[$"{new_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);
                            }
                            else
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Women\\{new_Product_id[i]}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                int pp_count = Convert.ToInt32(new_Count[i]);
                                int pp_amount = json_.offer_price * pp_count;

                                all_product_amount = all_product_amount + pp_amount;
                                all_product_count = all_product_count + pp_count;
                                des_product.product[$"{new_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);

                            }
                        }
                        else
                        {
                            var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{new_Product_id[i]}.json");
                            var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                            int pp_count = Convert.ToInt32(new_Count[i]);
                            int pp_amount = json_.offer_price * pp_count;

                            all_product_amount = all_product_amount + pp_amount;
                            all_product_count = all_product_count + pp_count;
                            des_product.product[$"{new_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);
                        }
                    }

                    des_product.total_product = all_product_count;
                    des_product.total_amount = all_product_amount;

                    var json = JsonConvert.SerializeObject(des_product);

                    Goto_cart_fun f  = new Goto_cart_fun();
                    f.cart_data = json;
                    f.user_id = c.User_id;
                    var da = cart_data.goto_cart(f);
                Total_list.Add(da);
                Total_list.Add(f);
                return Total_list;
                
              


            }
            else
            {

                var data = db.cart.Where(x => x.User_id == c.User_id).ToList();
                if (data.Count == 0)
                {
                    
                        dynamic des_product = JsonConvert.DeserializeObject<dynamic>(c.Product_data);

                        if (des_product.product.ContainsKey($"{c.Product_id}"))
                        {
                            string[] which_id = c.Product_id.Split('-');
                            if (which_id.Length > 1)
                            {
                                int file = Convert.ToInt32(which_id[1]);
                                if (file <= 155638)
                                {

                                    var json_data = File.ReadAllText($"D:\\Data\\Men\\{c.Product_id}.json");
                                    var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                    string P_id = des_product.product[$"{c.Product_id}"];
                                    string[] split_count = P_id.Split('|');
                                    int count = Convert.ToInt32(split_count[0]);
                                    int amount = Convert.ToInt32(split_count[1]);

                                    des_product.product.Remove($"{c.Product_id}");
                                    des_product.product.Add($"{c.Product_id}", $"{c.count}|{amount}");

                                }
                                else
                                {

                                    var json_data = File.ReadAllText($"D:\\Data\\Women\\{c.Product_id}.json");
                                    var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                    string P_id = des_product.product[$"{c.Product_id}"];
                                    string[] split_count = P_id.Split('|');
                                    int count = Convert.ToInt32(split_count[0]);
                                    int amount = Convert.ToInt32(split_count[1]);
                                    des_product.product.Remove($"{c.Product_id}");
                                    des_product.product.Add($"{c.Product_id}", $"{c.count}|{amount}");


                                }
                            }
                            else
                            {

                                var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{c.Product_id}.json");
                                var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                                string P_id = des_product.product[$"{c.Product_id}"];
                                string[] split_count = P_id.Split('|');
                                int count = Convert.ToInt32(split_count[0]);
                                int amount = Convert.ToInt32(split_count[1]);
                                des_product.product.Remove($"{c.Product_id}");
                                des_product.product.Add($"{c.Product_id}", $"{c.count}|{amount}");

                            }




                        }
                      

                        var get_new_product = des_product.product;
                        var new_product = JsonConvert.SerializeObject(get_new_product);

                        string new_removableChars = Regex.Escape(@"}@{&'\\()\<>""#+");
                        string new_pattern = "[" + new_removableChars + "]";
                        string new_regex = Regex.Replace(new_product, new_pattern, "");
                        string[] new_product_split = new_regex.Split(',');

                        for (int i = 0; i < new_product_split.Length; i++)
                        {
                            string[] split_product = new_product_split[i].Split(new char[] { '|', ':' });

                            new_Product_id.Add(split_product[0]);
                            new_Count.Add(Convert.ToInt32(split_product[1]));
                            new_Price.Add(Convert.ToDouble(split_product[2]));
                        }
                        for (int i = 0; i < new_Product_id.Count; i++)
                        {
                            string[] which_id_loop = new_Product_id[i].Split('-');
                            if (which_id_loop.Length > 1)
                            {
                                int file = Convert.ToInt32(which_id_loop[1]);
                                if (file <= 155638)
                                {
                                    var json_data = File.ReadAllText($"D:\\Data\\Men\\{new_Product_id[i]}.json");
                                    var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                    int pp_count = Convert.ToInt32(new_Count[i]);
                                    int pp_amount = json_.offer_price * pp_count;


                                    all_product_amount = all_product_amount + pp_amount;
                                    all_product_count = all_product_count + pp_count;
                                    des_product.product[$"{new_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);
                                }
                                else
                                {
                                    var json_data = File.ReadAllText($"D:\\Data\\Women\\{new_Product_id[i]}.json");
                                    var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                    int pp_count = Convert.ToInt32(new_Count[i]);
                                    int pp_amount = json_.offer_price * pp_count;

                                    all_product_amount = all_product_amount + pp_amount;
                                    all_product_count = all_product_count + pp_count;
                                    des_product.product[$"{new_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);

                                }
                            }
                            else
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{new_Product_id[i]}.json");
                                var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                                int pp_count = Convert.ToInt32(new_Count[i]);
                                int pp_amount = json_.offer_price * pp_count;

                                all_product_amount = all_product_amount + pp_amount;
                                all_product_count = all_product_count + pp_count;
                                des_product.product[$"{new_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);
                            }
                        }

                        des_product.total_product = all_product_count;
                        des_product.total_amount = all_product_amount;



                        Cart cart = new Cart();
                        cart.User_id = c.User_id;
                        cart.Product_data = JsonConvert.SerializeObject(des_product);
                        cart.Product_data = cart.Product_data;
                        db.cart.Add(cart);
                        db.SaveChanges();
                        Goto_cart_fun f = new Goto_cart_fun();
                        f.cart_data = cart.Product_data;
                        f.user_id = c.User_id;
                        var da = cart_data.goto_cart(f);
                       
                    Total_list.Add(da);
                    Total_list.Add(cart.Product_data);
                    return Total_list;





                }
                else
                {
                    dynamic exist_product = JsonConvert.DeserializeObject<dynamic>(data[0].Product_data);
                    dynamic new_product = JsonConvert.DeserializeObject<dynamic>(c.Product_data);

                    if (new_product.product.Count != null)
                    {

                        var get_new_product = new_product.product;
                        var new_product_data = JsonConvert.SerializeObject(get_new_product);

                        string new_removableChars = Regex.Escape(@"}@{&'\\()\<>""#+");
                        string new_pattern = "[" + new_removableChars + "]";
                        string new_username = Regex.Replace(new_product_data, new_pattern, "");
                        string[] new_product_split = new_username.Split(',');


                        for (int i = 0; i < new_product_split.Length; i++)
                        {
                            string[] split_product = new_product_split[i].Split(new char[] { '|', ':' });

                            new_Product_id.Add(split_product[0]);
                            new_Count.Add(Convert.ToInt32(split_product[1]));
                            new_Price.Add(Convert.ToDouble(split_product[2]));
                        }

                        for (int i = 0; i < new_Product_id.Count; i++)
                        {
                            if (exist_product.product.ContainsKey($"{new_Product_id[i]}"))
                            {
                                string[] product_id_ = new_Product_id[i].Split('-');
                                if (product_id_.Length > 1)
                                {
                                    int file_number = Convert.ToInt32(product_id_[1]);
                                    if (file_number <= 155638)
                                    {
                                        var json_data = File.ReadAllText($"D:\\Data\\Men\\{new_Product_id[i]}.json");
                                        var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                        string P_id = exist_product.product[$"{new_Product_id[i]}"];
                                        string[] split_count = P_id.Split('|');
                                        int count = Convert.ToInt32(split_count[0]);
                                        int amount = Convert.ToInt32(split_count[1]);
                                        exist_product.product[$"{new_Product_id[i]}"] = Convert.ToString(count + "|" + amount);
                                    }
                                    else
                                    {
                                        var json_data = File.ReadAllText($"D:\\Data\\Women\\{new_Product_id[i]}.json");
                                        var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                        string P_id = exist_product.product[$"{new_Product_id[i]}"];
                                        string[] split_count = P_id.Split('|');
                                        int count = Convert.ToInt32(split_count[0]);
                                        int amount = Convert.ToInt32(split_count[1]);

                                        exist_product.product[$"{new_Product_id[i]}"] = Convert.ToString(count + "|" + amount);
                                    }
                                }
                                else
                                {
                                    var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{new_Product_id[i]}.json");
                                    var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                                    string P_id = exist_product.product[$"{new_Product_id[i]}"];
                                    string[] split_count = P_id.Split('|');
                                    int count = Convert.ToInt32(split_count[0]);
                                    int amount = Convert.ToInt32(split_count[1]);

                                    exist_product.product[$"{new_Product_id[i]}"] = Convert.ToString(count + "|" + amount);
                                }

                            }
                            else
                            {
                                string[] whichid = new_Product_id[i].Split('-');
                                if (whichid.Length > 1)
                                {
                                    int file = Convert.ToInt32(whichid[1]);
                                    if (file <= 155638)
                                    {
                                        var json_data = File.ReadAllText($"D:\\Data\\Men\\{new_Product_id[i]}.json");
                                        var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                        string P_id = new_product.product[$"{new_Product_id[i]}"];
                                        string[] split_count = P_id.Split('|');
                                        int count = Convert.ToInt32(split_count[0]);
                                        int amount = Convert.ToInt32(split_count[1]);


                                        exist_product.product.Add($"{new_Product_id[i]}", $"{count}|{amount}");


                                    }
                                    else
                                    {
                                        var json_data = File.ReadAllText($"D:\\Data\\Women\\{new_Product_id[i]}.json");
                                        var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                        string P_id = new_product.product[$"{new_Product_id[i]}"];
                                        string[] split_count = P_id.Split('|');
                                        int count = Convert.ToInt32(split_count[0]);
                                        int amount = Convert.ToInt32(split_count[1]);


                                        exist_product.product.Add($"{new_Product_id[i]}", $"{count}|{amount}");

                                    }
                                }
                                else
                                {
                                    var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{new_Product_id[i]}.json");
                                    var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                                    string P_id = new_product.product[$"{new_Product_id[i]}"];
                                    string[] split_count = P_id.Split('|');
                                    int count = Convert.ToInt32(split_count[0]);
                                    int amount = Convert.ToInt32(split_count[1]);


                                    exist_product.product.Add($"{new_Product_id[i]}", $"{count}|{amount}");

                                }

                            }

                        }
                    }

                    if (exist_product.product.ContainsKey($"{c.Product_id}"))
                    {
                        string[] product_id_ = c.Product_id.Split('-');
                        if (product_id_.Length > 1)
                        {
                            int file_number = Convert.ToInt32(product_id_[1]);
                            if (file_number <= 155638)
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Men\\{c.Product_id}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);

                        

                                string P_id = exist_product.product[$"{c.Product_id}"];
                                string[] split_count = P_id.Split('|');
                                int count = Convert.ToInt32(split_count[0]);
                                int amount = Convert.ToInt32(split_count[1]);

                                exist_product.product[$"{c.Product_id}"] = Convert.ToString(c.count + "|" + amount);
                            }
                            else
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Women\\{c.Product_id}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);


                                string P_id = exist_product.product[$"{c.Product_id}"];
                                string[] split_count = P_id.Split('|');
                                int count = Convert.ToInt32(split_count[0]);
                                int amount = Convert.ToInt32(split_count[1]);

                                exist_product.product[$"{c.Product_id}"] = Convert.ToString(c.count + "|" + amount);
                            }
                        }
                        else
                        {
                            var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{c.Product_id}.json");
                            var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);

                            string P_id = exist_product.product[$"{c.Product_id}"];
                            string[] split_count = P_id.Split('|');
                            int count = Convert.ToInt32(split_count[0]);
                            int amount = Convert.ToInt32(split_count[1]);

                            exist_product.product[$"{c.Product_id}"] = Convert.ToString(c.count + "|" + amount);
                        }

                    }
                    else
                    {
                        string[] whichid = c.Product_id.Split('-');
                        if (whichid.Length > 1)
                        {
                            int file = Convert.ToInt32(whichid[1]);
                            if (file <= 155638)
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Men\\{c.Product_id}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);

                                int count = c.count;
                                int amount = c.count * json_.offer_price;


                                exist_product.product.Add($"{c.Product_id}", $"{count}|{amount}");


                            }
                            else
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Women\\{c.Product_id}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                int count = c.count;
                                int amount = c.count * json_.offer_price;


                                exist_product.product.Add($"{c.Product_id}", $"{count}|{amount}");

                            }
                        }
                        else
                        {
                            var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{c.Product_id}.json");
                            var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                            int count = c.count;
                            int amount = c.count * json_.offer_price;


                            exist_product.product.Add($"{c.Product_id}", $"{count}|{amount}");

                        }

                    }





                    var exist_new_product = exist_product.product;
                    var exist_product_data = JsonConvert.SerializeObject(exist_new_product);

                    string exist_removableChars = Regex.Escape(@"}@{&'\\()\<>""#+");
                    string exist_pattern = "[" + exist_removableChars + "]";
                    string exist_regex = Regex.Replace(exist_product_data, exist_pattern, "");
                    string[] exist_product_split = exist_regex.Split(',');

                    for (int i = 0; i < exist_product_split.Length; i++)
                    {
                        string[] split_product = exist_product_split[i].Split(new char[] { '|', ':' });

                        exist_Product_id.Add(split_product[0]);
                        exist_Count.Add(Convert.ToInt32(split_product[1]));
                        exist_Price.Add(Convert.ToDouble(split_product[2]));
                    }
                    for (int i = 0; i < exist_Product_id.Count; i++)
                    {
                        string[] which_id_loop = exist_Product_id[i].Split('-');
                        if (which_id_loop.Length > 1)
                        {
                            int file = Convert.ToInt32(which_id_loop[1]);
                            if (file <= 155638)
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Men\\{exist_Product_id[i]}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                int pp_count = Convert.ToInt32(exist_Count[i]);
                                int pp_amount = json_.offer_price * pp_count;


                                exist_all_product_amount = exist_all_product_amount + pp_amount;
                                exist_all_product_count = exist_all_product_count + pp_count;
                                exist_product.product[$"{exist_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);
                            }
                            else
                            {
                                var json_data = File.ReadAllText($"D:\\Data\\Women\\{exist_Product_id[i]}.json");
                                var json_ = JsonConvert.DeserializeObject<ajio>(json_data);
                                int pp_count = Convert.ToInt32(exist_Count[i]);
                                int pp_amount = json_.offer_price * pp_count;


                                exist_all_product_amount = exist_all_product_amount + pp_amount;
                                exist_all_product_count = exist_all_product_count + pp_count;
                                exist_product.product[$"{exist_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);

                            }
                        }
                        else
                        {
                            var json_data = File.ReadAllText($"D:\\Data\\Electronics\\{exist_Product_id[i]}.json");
                            var json_ = JsonConvert.DeserializeObject<Electronics>(json_data);
                            int pp_count = Convert.ToInt32(exist_Count[i]);
                            int pp_amount = json_.offer_price * pp_count;


                            exist_all_product_amount = exist_all_product_amount + pp_amount;
                            exist_all_product_count = exist_all_product_count + pp_count;
                            exist_product.product[$"{exist_Product_id[i]}"] = Convert.ToString(pp_count + "|" + pp_amount);
                        }
                    }

                    exist_product.total_product = exist_all_product_count;
                    exist_product.total_amount = exist_all_product_amount;

                    Cart cart = new Cart();
                    cart.User_id = c.User_id;
                    cart.Product_data = JsonConvert.SerializeObject(exist_product);
                    data[0].Product_data = cart.Product_data;
                    db.cart.Update(data[0]);
                    db.SaveChanges();
                    Goto_cart_fun f = new Goto_cart_fun();
                    f.cart_data = cart.Product_data;
                    f.user_id = c.User_id;
                    var da = cart_data.goto_cart(f);
                    Total_list.Add(da);
                    Total_list.Add(cart.Product_data);
                    return Total_list;
                   



                }




            }
        }
    }
}
