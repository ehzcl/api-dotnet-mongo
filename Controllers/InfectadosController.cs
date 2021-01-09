using mongo_dotnet.Models;
using mongo_dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web;

namespace mongo_dotnet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfectadosController
    {
        private readonly InfectadoService _infectadoService;

        public InfectadosController(InfectadoService infectadoService) {
            _infectadoService = infectadoService;
        }
    
        [HttpGet]
        public ActionResult<List<Infectado>> Get() =>
            _infectadoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetInfectado")]
        public ActionResult<Infectado> Get(string id) {
            var inf = _infectadoService.Get(id);

            if (inf == null) {
                // return NotFound();
            }
            return inf;
        }

        [HttpPost]
        public ActionResult<Infectado> Create(Infectado inf) {
            _infectadoService.Create(inf);

            return CreatedAtRoute("GetInfectado", new { id = inf.Id.ToString()}, inf);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Infectado i) {
            var inf = _infectadoService.Get(id);

            if (inf == null ) {
                
            }

            _infectadoService.Update(id, inf);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var inf = _infectadoService.Get(id);

            if (inf == null)
            {
                return NotFound();
            }

            _infectadoService.Remove(inf.Id);

            return NoContent();
        }
    }
}