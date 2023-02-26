using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model;
using System.Runtime.InteropServices;

namespace shopyway.Implements
{
    public class partner_account:IPartner
    {
        private readonly DataContext db;
        public partner_account(DataContext _db)
        {
            this.db = _db;
        }


        public dynamic partner_Registeration(Partner_user user)
        {
            Messages msg = new Messages();
            try
            {
                var data = db.partner_Users.Where(u => u.email == user.email || u.mobile == user.mobile).ToList();

                if (data.Count != 0)
                {
                    msg.Message = "User Already Exist";
                    msg.status = "Ok";
                    return msg;
                }
                else
                {
                    Partner_user u = new Partner_user();

                    u.first_name = user.first_name;
                    u.last_name = user.last_name;
                    var m_ = Convert.ToString(user.mobile);
                    if (m_.Length == 10)
                    {
                        u.mobile = user.mobile;
                    }
                    u.gst = user.gst;
                    if (user.email.Length > 4)
                    {
                        u.email = user.email;
                    }
                    u.password = user.password;
                    u.site= user.site;
                    if(!Directory.Exists($@"D:\Partner_data\"+user.site))
                    {
                        Directory.CreateDirectory($@"D:\Partner_data\" + user.site);
                        File.Create($@"D:\Partner_data\{ user.site}\Main.json").Dispose();
                        Directory.CreateDirectory($@"D:\Partner_data\{user.site}\Database");
                        Directory.CreateDirectory($@"D:\Partner_data\{user.site}\Images");
                        Directory.CreateDirectory($@"D:\Partner_data\{user.site}\Banner");
                        Directory.CreateDirectory($@"D:\Partner_data\{user.site}\Menu");
                    }
                    db.partner_Users.Add(u);

                    add_site(user.site,user.mobile);
                    msg.Message = "User Register Successfully";
                    msg.status = "Ok";
                    return msg;
                }
            }
            catch (Exception er)
            {

                msg.Message = er.Message;
                msg.status = "Not Ok";
                return msg;
            }


        }


        public dynamic partner_Login(Login_User login)
        {
            try
            {

                bool response;
                long a;
                response = long.TryParse(login.User_name, out a);
                if (response)
                {
                    long number = Convert.ToInt64(login.User_name);
                    var data = db.partner_Users.Where(x => x.mobile == number && x.password == login.User_Password).ToList();
                    if (data.Count != 0)
                    {
                        var userdata = new
                        {
                            message = "success",
                            fullname = data[0].first_name+" " + data[0].last_name,
                            id = data[0].partner_id

                        };
                        return userdata;
                    }
                    else
                    {
                        Messages msg = new Messages();
                        msg.Message = "User Not Exist";
                        msg.status = "Ok";

                        return msg;
                    }

                }
                else
                {
                    var data = db.partner_Users.Where(x => x.email == login.User_name && x.password == login.User_Password).ToList();
                    if (data.Count != 0)
                    {
                        var userdata = new
                        {
                            message = "success",
                            fullname = data[0].first_name + " " + data[0].last_name,
                            id = data[0].partner_id
                        };
                        return userdata;
                    }
                    else
                    {
                        Messages msg = new Messages();
                        msg.Message = "User Not Exist";
                        msg.status = "Ok";

                        return msg;
                    }


                }
            }
            catch (Exception er)
            {

                Messages msg = new Messages();
                msg.Message = er.Message;
                msg.status = "Not Ok";

                return msg;
            }


        }

        public dynamic check_site(string id)
        {
            var data = db.site.Where(x => x.sites == id).ToList();
            if(data.Count != 0)
            {
                Messages msg = new Messages();
                msg.Message = "Already Taken";
                msg.status = "Ok";
                return msg;
            }
            else
            {
                
                Messages msg = new Messages();
                msg.Message = "Not Taken";
                msg.status = "Ok";
                return msg;
            }
        }

        public void add_site(string id,long user)
        {
            site s = new site();
            s.sites = id;
            s.user_id = Convert.ToString(user);
            db.site.Add(s);
           
        }
        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}
