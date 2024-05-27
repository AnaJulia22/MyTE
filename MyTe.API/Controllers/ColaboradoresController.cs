using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyTe.API.Models.Contexts;
using MyTe.API.Models.DTO;
using MyTe.API.Services;

namespace MyTe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly ColaboradoresService colaboradoresService;
        
        public ColaboradoresController(ColaboradoresService colaboradoresService)
        {
            this.colaboradoresService = colaboradoresService;    
        }

       
        [HttpGet]
        public IActionResult ListarColaboradoresDTO()
        {
            return Ok(colaboradoresService.ListarColaboradoresDTO());
        }
        
    }
}
