using Microsoft.EntityFrameworkCore;
using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;

namespace shopyway.Implements
{
    public class Search : Isearch
    {
        private readonly DataContext db;
        public Search(DataContext _db)
        {
            this.db = _db;
        }

        public dynamic search_product(Search_fun search)
        {

           

           if(search.search_type == "Men")
            {
                try
                {
                    var data = db.Ajiomen.FromSqlRaw($@"select top 50 * from Ajiomen where Product_name like '%{search.search}%'");
                    return data;
                }
                catch (Exception er)
                {
                    Messages msg = new Messages();

                    msg.Message = er.Message;
                    msg.status = "Not Ok";

                    return msg;
                }
            }
            if (search.search_type == "Women")
            {
                try
                {
                    var data = db.Ajiowomen.FromSqlRaw($@"select top 50 * from Ajiowomen where Product_name like '%{search.search}%'");
                    return data;
                }
                catch (Exception er)
                {
                    Messages msg = new Messages();

                    msg.Message = er.Message;
                    msg.status = "Not Ok";

                    return msg;
                }
            }
            if (search.search_type == "Electronics")
            {
                try
                {
                    var data = db.products.FromSqlRaw($@"select top 50 * from products where Product_name like '%{search.search}%'");
                    return data;
                }
                catch (Exception er)
                {
                    Messages msg = new Messages();

                    msg.Message = er.Message;
                    msg.status = "Not Ok";

                    return msg;
                }
            }
            if (search.search_type == "Mobile")
            {
                try
                {
                    var data = db.products.FromSqlRaw($@"select top 50 * from products where Product_name like '%{search.search}%' and type = 'Mobile'");
                    return data;
                }
                catch (Exception er)
                {
                    Messages msg = new Messages();

                    msg.Message = er.Message;
                    msg.status = "Not Ok";

                    return msg;
                }
            }

            return "something";
        }
    }
}
