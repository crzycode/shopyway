using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Electronic_product_category : ControllerBase
    {
        private readonly IElectronic_category_product db;
        public Electronic_product_category(IElectronic_category_product db)
        {
            this.db = db;
        }

        [HttpGet]
        public dynamic get_mobile_laptop_category_product()
        {
            var data = db.get_Electronic_product_category();
            return data;
        }
    }
}
