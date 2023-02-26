using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopDealsController : ControllerBase
    {
        private readonly ITop_deals td;
        public TopDealsController(ITop_deals _td)
        {
            this.td = _td;
        }

        [HttpGet("Device")]
       
        public dynamic devices()
        {
            var data = td.Device();
            return data;
        }
        [HttpGet("Electronic")]
        
        public dynamic electronic()
        {
            var data = td.Electronics();
            return data;
        }
        [HttpGet("Fashion")]
      
        public dynamic fashion()
        {
            var data = td.Fashion();
            return data;
        }


    }
}
