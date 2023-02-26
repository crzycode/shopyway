using shopyway.Context;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model;

namespace shopyway.Implements
{
    public class User_Register : IUser_Register
    {
        private readonly DataContext db;
        public User_Register(DataContext _db)
        {
            this.db = _db;
        }
      

        public dynamic User_Registeration(User_Register_Function user)
        {
            Messages msg = new Messages();
            try
            {
                var data = db.users.Where(u => u.User_Email == user.User_Email || u.User_Mobilenumber == user.User_Mobilenumber).ToList();

                if (data.Count != 0)
                {
                    msg.Message = "User Already Exist";
                    msg.status = "Ok";
                    return msg;
                }
                else
                {
                    User u = new User();

                    u.User_Fullname= user.User_Fullname;
                    if (user.User_Mobilenumber > 123456789)
                    {
                        u.User_Mobilenumber = user.User_Mobilenumber;
                    }
                    if(user.User_Email.Length > 4)
                    {
                        u.User_Email = user.User_Email;
                    }
                    u.User_Password= user.User_Password;

                    db.users.Add(u);
                    savechanges();
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

       
        public dynamic User_Login(Login_User login)
        {
            try
            {
                
                bool response;
                long a;
                response = long.TryParse(login.User_name, out a);
                if (response)
                {
                    long number = Convert.ToInt64(login.User_name);
                    var data = db.users.Where(x => x.User_Mobilenumber == number && x.User_Password == login.User_Password).ToList();
                    if (data.Count != 0)
                    {
                        var userdata = new
                        {
                            message = "success",
                            fullname = data[0].User_Fullname,
                            id = data[0].User_id

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
                    var data = db.users.Where(x => x.User_Email == login.User_name && x.User_Password == login.User_Password).ToList();
                    if (data.Count != 0)
                    {
                        var userdata = new
                        {
                            message = "success",
                            fullname = data[0].User_Fullname,
                            id = data[0].User_id
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
        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}
