using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Top_elec_categoryController : ControllerBase
    {
        private readonly ITop_category db;
        public Top_elec_categoryController(ITop_category _db)
        {
            this.db = _db;

        }
        [HttpGet]
        public dynamic get_top_elec_catagory()
        {
            var data = db.get_top_category();
            return data;
        }
    }
}
