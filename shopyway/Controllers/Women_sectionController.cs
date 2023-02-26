using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Women_sectionController : ControllerBase
    {
        private readonly IWomen_section db;
        public Women_sectionController(IWomen_section db)
        {
            this.db = db;
        }

        [HttpGet]
        public dynamic men_section_controller()
        {
            var data = db.women_section_data();
            return data;
        }
    }
}
