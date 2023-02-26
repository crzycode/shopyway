using shopyway.Context;
using shopyway.Interface;

namespace shopyway.Implements
{
    public class top_category : ITop_category
    {
        private readonly DataContext db;
        public top_category(DataContext _db)
        {
            this.db = _db;
        }
        public dynamic get_top_category()
        {
            var data = db.elec_category.ToList();
            return data;
        }
    }
}
