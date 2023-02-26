using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_Get_partner_dataController : ControllerBase
    {
        private readonly IGet_partner_data db;
        public C_Get_partner_dataController(IGet_partner_data _db)
        {
            this.db = _db;
        }

        [HttpGet("{id}")]
        public dynamic get_partner_data_action(string id)
        {
            var data = db.get_data(id);
            return data;
        }
    }
}
