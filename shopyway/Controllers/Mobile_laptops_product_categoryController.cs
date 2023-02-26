using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_laptops_product_categoryController : ControllerBase
    {
        private readonly IMobile_laptop_category_product db;
        public Mobile_laptops_product_categoryController(IMobile_laptop_category_product db)
        {
            this.db = db;
        }

        [HttpGet]
        public dynamic get_mobile_laptop_category_product()
        {
            var data = db.get_mobile_laptop_category();
            return data;
        }
    }
}
