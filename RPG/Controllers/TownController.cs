using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers {

    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class TownController : ControllerBase {
        
        [HttpPost]
        [Route("buy")]
        public string buyItem() {
            return "undefined";
        }
    }
}
