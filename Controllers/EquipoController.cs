using Microsoft.AspNetCore.Mvc;
using GestorTorneosAPI.Models;

namespace GestorTorneosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquiposController : ControllerBase
    {
        private static List<Equipo> equipos = new List<Equipo>
        {
            new Equipo { Id = 1, Nombre = "Porcinos FC", Presidente = "Ibai", Puntos = 12 },
            new Equipo { Id = 2, Nombre = "Skull FC", Presidente = "Marcelo", Puntos = 9 }
        };

        [HttpGet]
        public IActionResult Get() => Ok(equipos);

        [HttpPost]
        public IActionResult Post([FromBody] Equipo nuevoEquipo)
        {
            nuevoEquipo.Id = equipos.Count + 1;
            equipos.Add(nuevoEquipo);
            return CreatedAtAction(nameof(Get), new { id = nuevoEquipo.Id }, nuevoEquipo);
        }
    }
}