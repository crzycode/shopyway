using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Men_sectionController : ControllerBase
    {
        private readonly IMen_section db;
        public Men_sectionController(IMen_section db)
        {
            this.db = db;
        }

        [HttpGet]
        public dynamic men_section_controller()
        {
            var data = db.men_section_data();
            return data;
        }
    }
}
