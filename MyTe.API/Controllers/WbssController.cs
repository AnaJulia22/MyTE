using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTe.API.Models;
using MyTe.API.Services;

namespace MyTe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WbssController : ControllerBase
    {
        private readonly WbssService wbssService;

        public WbssController(WbssService wbssService)
        {
            this.wbssService = wbssService;
        }
     
        [HttpGet]
        public IActionResult ListarWbsDTO()
        {
            return Ok(wbssService.ListarWbsDTO());
        }

       

    }
}
