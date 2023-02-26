using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopyway.Function;
using shopyway.Interface;

namespace shopyway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly Isearch db;
        public SearchController(Isearch db)
        {
            this.db = db;
        }

        [HttpPost]
        public dynamic search_product(Search_fun search)
        {
            var data = db.search_product(search);
            return data;
        }
    }
}
