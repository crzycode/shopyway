using Microsoft.EntityFrameworkCore;
using shopyway.Context;
using shopyway.Interface;

namespace shopyway.Implements
{
    public class TopElec_products_:ITopElec_products
    {
        private readonly DataContext db;
        public TopElec_products_(DataContext _db)
        {
            this.db = _db;
        }

        public dynamic top_electronic_product()
        {
            var data = db.topElec.FromSqlRaw("SELECT TOP 20 * FROM topElec ORDER BY NEWID()").ToList();
            return data;
            
        }
    }
}
