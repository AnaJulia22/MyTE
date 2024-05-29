using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTe.API.Services;

namespace MyTe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WbsApiController : ControllerBase
    {
        private readonly WbssService wbssService;
        public WbsApiController(WbssService wbssService)
        {
            this.wbssService = wbssService;
        }
        [HttpGet]
        public IActionResult ListarCandidatos()
        {
            return Ok(wbssService.ListarWbsDTO());
        }
    }
}
