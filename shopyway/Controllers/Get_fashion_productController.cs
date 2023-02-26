using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Get_fashion_productController : ControllerBase
    {
        private readonly IGet_fashion_product db;
        public Get_fashion_productController(IGet_fashion_product db)
        {
            this.db = db;
        }

        [HttpGet]
        public dynamic get_fashion()
        {
            var data = db.get_fash_products();
            return data;
        }
    }

}
