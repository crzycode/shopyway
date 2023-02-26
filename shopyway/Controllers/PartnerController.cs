using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartner db;
        public PartnerController(IPartner db)
        {
            this.db = db;
        }
        [HttpPost]
        public dynamic add_partner_data(Partner_user p)
        {
            var data = db.partner_Registeration(p);
            db.savechanges();
            return data;
        }
        [HttpPost("login")]
        public dynamic login_partner(Login_User u)
        {
            var data = db.partner_Login(u);
            return data;
        }
        [HttpGet("{id}")]
        public dynamic check_site(string id)
        {
            var data = db.check_site(id);
            return data;
        }
    }
}
