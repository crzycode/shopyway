using shopyway.Context;
using shopyway.Interface;
using shopyway.Model;

namespace shopyway.Implements
{
    public class Get_partner_data_ : IGet_partner_data
    {
        private readonly DataContext db;

        public Get_partner_data_(DataContext db)
        {
            this.db = db;
        }

        public dynamic get_data(string id)
        
        {
            var data = db.site.Where(x => x.sites == id).ToList();
            if(data.Count != 0) {
                var list = File.ReadAllLines($@"D:\Partner_data\{id}\Main.json").ToList();
                return list;
            }
            else
            {
                return "user not exist";
            }
        }
    }
}
