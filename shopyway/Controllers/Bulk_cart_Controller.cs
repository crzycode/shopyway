using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Function;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Bulk_cart_Controller : ControllerBase
    {
        private readonly IBulk_add_to_cart db;
        public Bulk_cart_Controller(IBulk_add_to_cart db)
        {
            this.db = db;
        }
        [HttpPost]
        public dynamic bulkcart(cart_f f)
        {
            var data = db.bulk_add_cart(f);
            return data;
        }
    }
}
