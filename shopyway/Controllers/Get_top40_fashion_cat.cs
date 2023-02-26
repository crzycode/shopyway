using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Get_top40_fashion_cat : ControllerBase
    {
        private readonly ITop_fashion_category db;
        public Get_top40_fashion_cat(ITop_fashion_category db)
        {
            this.db = db;
        }

        [HttpGet]
        public dynamic get_fashion_category()
        {
            var data = db.get_fashion_category();
            return data;
        }
    }
}
