using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Function;
using shopyway.Interface;
using shopyway.Model;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Add_to_cartController : ControllerBase
    {
        private readonly ICart db;
        public Add_to_cartController(ICart db)
        {
            this.db = db;
        }
        [HttpPost]
        public dynamic addtocart(cart_f c)
        {
            var data = db.add_to_cart(c);
            return data;
        }
        [HttpPost("cartdata")]
        public dynamic got_cart(Goto_cart_fun f)
        {
           var data = db.goto_cart(f);
            return data;
        }

        [HttpPost("remove")]
        public dynamic remove(cart_f c)
        {
            var data = db.remove_cart(c);
            return data;
        }
    }
}
