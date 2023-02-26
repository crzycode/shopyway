using Microsoft.EntityFrameworkCore;
using shopyway.Context;
using shopyway.Interface;
using shopyway.Model;
using shopyway.Model.Fashion;

namespace shopyway.Implements
{
    public class Top_fashion_category : ITop_fashion_category
    {
        private readonly DataContext db;
        public Top_fashion_category(DataContext _db)
        {
            this.db= _db;
        }
        public dynamic get_fashion_category()
        {
            List<dynamic> totlalcategory = new List<dynamic>();

            var data = db.fashion_Categories.FromSqlRaw("select top 40 * from fashion_Categories ORDER BY NEWID()").ToList();
            int k = 0;
            int divided = 10;
            var databy = data.Count / divided;
            for (int i = 0; i < divided; i++)
            {
                List<Fashion_category> top4category = new List<Fashion_category>();
                for (int l  = 0; l < databy; l++)
                {
                    Fashion_category f = new Fashion_category();
                    f.type = data[k].type;
                    f.image_name = data[k].image_name;
                    top4category.Add(f);
                    k++;
                }
                totlalcategory.Add(top4category);
            }

            return totlalcategory;
        }
    }
}
