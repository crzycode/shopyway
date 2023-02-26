using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopElectronics : ControllerBase
    {
        private readonly ITopElec_products db;
        public TopElectronics(ITopElec_products _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public dynamic topelectronics()
        {
            var data = db.top_electronic_product();
            return data;
        }
    }
}
