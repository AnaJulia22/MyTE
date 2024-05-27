using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTe.API.Services;

namespace MyTe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroHorasController : ControllerBase
    {
        private readonly RegistrosHorasService registrosHorasService;

        public RegistroHorasController(RegistrosHorasService registrosHorasService)
        {
            this.registrosHorasService = registrosHorasService;   
        }
        [HttpGet]

        public IActionResult ListarRegistrosDTO() 
        { 
            return Ok(registrosHorasService.ListarRegistrosDTO());
        }
    }
}
