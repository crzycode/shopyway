using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using shopyway.Context;
using shopyway.Model;

using shopyway.Model.Fashion;
using System;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private readonly DataContext db;
        public ReadController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public dynamic adddata()
        {
            /* var datat = db.gettype_Funs.FromSqlRaw("select Article_type from styles where Category = 'Accessories' group by Article_type  Having Count(*) > 1").ToList();

             for (int i = 0; i < datat.Count; i++)
             {
                 var stylish = db.styles.FromSqlRaw($"select top 1 * from styles where Article_type ='{datat[i].Article_type}'  ORDER BY NEWID()").ToList();

                 Accessory_category f = new Accessory_category();
                 f.type = stylish[0].Article_type;
                 f.image_name = stylish[0].Image_name;

                 db.Accessory_category.Add(f);
                 db.SaveChanges();

             }*/
            return "success";
        }
        [HttpGet("fashion_product")]
        public dynamic get_fashion()
        {
         /*   var datat = db.gettype_Funs.FromSqlRaw("select Article_type from styles where Category = 'Accessories' group by Article_type  Having Count(*) > 1").ToList();

            for (int i = 0; i < datat.Count; i++)
            {
                var stylish = db.styles.FromSqlRaw($"select top 1 * from styles where Article_type ='{datat[i].Article_type}'  ORDER BY NEWID()").ToList();
                for (int k = 0; k < stylish.Count; k++)
                {
                    Accessory_product t = new Accessory_product();


                    t.file_name = stylish[k].file_name;
                    t.Gender = stylish[k].Gender;
                    t.Category = stylish[k].Category;
                    t.SubCategory = stylish[k].SubCategory;
                    t.Article_type = stylish[k].Article_type;
                    t.Color = stylish[k].Color;
                    t.Season = stylish[k].Season;
                    t.Usage = stylish[k].Usage;
                    t.Product_name = stylish[k].Product_name;

                    t.Image_name = stylish[k].Image_name;

                    t.offer_price = stylish[k].offer_price;
                    t.original_price = stylish[k].original_price;
                    t.off_now = stylish[k].off_now;
                    t.total_rating = stylish[k].total_rating;
                    t.total_reviews = stylish[k].total_reviews;
                    t.rating = stylish[k].rating;

                    db.Accessory_product.Add(t);
                    db.SaveChanges();
                }



            }*/
            return "success";
        }

        [HttpGet("style_purify")]
        public dynamic purifystyle_type()
        {
           /* var data = db.styles.ToList();
            for (int i = 0; i < data.Count; i++)
            {
                var Des = System.IO.File.ReadAllText($"D:\\Downloads\\fashion-dataset\\styles\\{data[i].file_name}.json");
                dynamic json = JsonConvert.DeserializeObject<dynamic>(Des);
                Random rnd = new Random();
                int discount = rnd.Next(10, 40);

                var Original_price = Convert.ToInt32(json.data.price);

                var discounte_price = Original_price * discount / 100;

                data[i].off_now = discount + " %" + " Off";
                data[i].original_price = Original_price;
                data[i].offer_price = Original_price - discounte_price;


                db.styles.Update(data[i]);
                db.SaveChanges();


            }*/







            /* 840 * 30 / 100*/
            /* var datat = db.styles.ToList();*/

           
            return "success";
        }
        /*public dynamic dynamicGet()
        {
            List<dynamic> list = new List<dynamic>();

            var data = db.mytable.Take(62196).ToList();
            for (int i = 0; i < data.Count; i++)
            {

                Style s = new Style();

                if (data[i].brand != null)
                {
                    s.Brand_name = data[i].brand;
                }
                else
                {
                    s.Brand_name = "Not Available";
                }
                if (data[i].title != null)
                {
                    s.Product_name= data[i].title;
                }
                else
                {
                    s.Product_name = "not Available";
                }
                if (data[i].sold_price != null)
                {
                    string[] U_product_split = data[i].sold_price.Split(',');

                    if (U_product_split.Length > 1)
                    {
                        var price = U_product_split[0] + U_product_split[1];
                        s.offer_price = Convert.ToInt32(price);
                    }
                    else
                    {
                        var price = U_product_split[0];
                        s.offer_price = Convert.ToInt32(price);
                    }
                }
                else
                {
                    s.offer_price = 0;
                }
                if (data[i].actual_price != null)
                {
                    
                    string[] U_product_split = data[i].actual_price.Split(',');

                    if(U_product_split.Length > 1)
                    {
                        var price = U_product_split[0] + U_product_split[1];
                        s.original_price = Convert.ToInt32(price);
                    }
                    else
                    {
                        var price = U_product_split[0];
                        s.original_price = Convert.ToInt32(price);
                    }

                    
                }
                else
                {
                    s.original_price = 0;
                }
                if (data[i].img != null)
                {
                    string U_removableChars = Regex.Escape(@"}@{&'\\,()\<>""#+");
                    string U_pattern = "[" + U_removableChars + "]";
                    string U_username = Regex.Replace(data[i].img, U_pattern, "");
                    string[] U_product_split_data = U_username.Split('/');

                    if(U_product_split_data[7].Length > 1)
                    {
                        s.type = U_product_split_data[7];
                    }
                    else
                    {
                        s.type = U_product_split_data[6];
                    }

                    
                }
                else
                {
                    s.type = "others";
                }

                if (data[i].id != 0)
                {
                    s.image= data[i].id;
                }
                var offprice = s.original_price - s.offer_price;
                var discountamount = offprice / s.original_price;
                 var total_amount = Convert.ToDouble(discountamount * 100);

               var discount = (double)System.Math.Round(total_amount, 1);
                s.off_now = Convert.ToString(discount);

                db.styles.Add(s);
                db.SaveChanges();

            }
            return list;
        }*/

        [HttpGet("download")]
        public dynamic download_image()
        {


         /*   WebClient client = new WebClient();

            var data = db.myntras.ToList();
            for (int i = 0; i < data.Count; i++)
            {
                *//* client.DownloadFile(new Uri(data[i].img), $@"D:\Image_server\Clothes\{data[i].p_id}.jpg");
                 // OR 
                 client.DownloadFileAsync(new Uri(), );*//*
                if(data[i].img.Length > 4)
                {
                    byte[] dataArr = client.DownloadData(data[i].img);
                    //save file to local
                    System.IO.File.WriteAllBytes($@"D:\Image_server\Clothes\myntra\{data[i].p_id}.jpg", dataArr);
                }

                
            }*/

           /* using (WebClient webClient = new WebClient())
            {
                
            }*/




            return "success";
        }

      
    }

  
}
