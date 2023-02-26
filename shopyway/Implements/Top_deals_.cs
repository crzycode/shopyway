using Microsoft.EntityFrameworkCore;
using shopyway.Context;
using shopyway.Interface;
using shopyway.Model.Topdeals;

namespace shopyway.Implements
{
    public class Top_deals_ : ITop_deals
    {
        private readonly DataContext db;
        public Top_deals_(DataContext _db)
        {
            this.db = _db;
        }

        public dynamic Device()
        {
            var data = db.topdeals.FromSqlRaw("select * from topdeals where Deal_type = 'Devices'").ToList();
            return data;
        }

        public dynamic Electronics()
        {
            var data = db.topdeals.FromSqlRaw("select * from topdeals where Deal_type = 'Electronic'").ToList();
            return data;
        }

        public dynamic Fashion()
        {
            var data = db.topdeals.FromSqlRaw("select * from topdeals where Deal_type = 'Fashion'").ToList();
            return data;
        }
    }
}
