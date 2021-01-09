using mongo_dotnet.Models;
using mongo_dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace mongo_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfectadosController : Controller
    {
        private readonly InfectadosService _infectadosService; 

        public InfectadosController(InfectadosService infectadosService) {
            _infectadosService = infectadosService;
        }

        [HttpGet]
        public ActionResult<List<Infectado>> Get () => _infectadosService.Get();

        [HttpGet("{id:length(24)}", Name = "GetInfectado")]
        public ActionResult<Infectado> Get(string id)
        {
            var infectado = _infectadosService.Get(id);

            if (infectado == null)
                return NotFound();

            return infectado;
        }

        [HttpPost]
        public ActionResult<Infectado> Create(Infectado infectado)
        {
            _infectadosService.Create(infectado);

            return CreatedAtRoute("GetInfectado", new { id = infectado.Id.ToString() }, infectado);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Infectado infectadoIn)
        {
            var i = _infectadosService.Get(id);

            if (i == null)
                return NotFound();

            _infectadosService.Update(id,infectadoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var i = _infectadosService.Get(id);

            if (i == null)
                return NotFound();

            _infectadosService.Remove(i.Id);

            return NoContent();
        }
    }
}