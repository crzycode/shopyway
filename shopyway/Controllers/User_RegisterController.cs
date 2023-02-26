using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Function;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_RegisterController : ControllerBase
    {
        private readonly IUser_Register db;

        public User_RegisterController(IUser_Register _db)
        {
            db= _db;
        }

        [HttpPost]
        public dynamic User_register(User_Register_Function user)
        {
            var data = db.User_Registeration(user);
            return data;
        }
        [HttpPost("login")]
        public dynamic User_login(Login_User login)
        {
            var data = db.User_Login(login);
            return data;
        }
    }
}
