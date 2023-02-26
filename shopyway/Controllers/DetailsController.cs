using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetails db;
        public DetailsController(IDetails db)
        {
            this.db = db;
        }
        [HttpGet("{id}")]
        public dynamic get_details_data(string id) {
            var data = db.get_details(id);
            return data;
        }

        [HttpGet("type/{type}")]
        public dynamic details_data(string type)
        {
            var data = db.get_add_data(type);
            return data;
        }
        [HttpGet("types/{id}")]
        public dynamic get_ele_details_data(string id)
        {
            var data = db.get_elec_add_data(id);
            return data;
        }
    }
}
