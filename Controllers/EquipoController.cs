using Microsoft.AspNetCore.Mvc;
using GestorTorneosAPI.Models;
using GestorTorneosAPI.Common;

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
        public IActionResult GetAll()
        {
            var response = ApiResponse<List<Equipo>>.Ok(equipos, "Lista de equipos obtenida correctamente.");
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var equipo = equipos.FirstOrDefault(e => e.Id == id);
            if (equipo == null)
            {
                return NotFound(new { success = false, message = $"No se encontró el equipo con ID {id}" });
            }

            var response = ApiResponse<Equipo>.Ok(equipo, "Equipo encontrado.");
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Equipo nuevoEquipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            nuevoEquipo.Id = equipos.Count > 0 ? equipos.Max(e => e.Id) + 1 : 1;
            equipos.Add(nuevoEquipo);

            var response = ApiResponse<Equipo>.Ok(nuevoEquipo, "Equipo creado exitosamente.");
            return CreatedAtAction(nameof(GetById), new { id = nuevoEquipo.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Equipo equipoActualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipoExistente = equipos.FirstOrDefault(e => e.Id == id);
            if (equipoExistente == null)
            {
                return NotFound(new { success = false, message = $"No se encontró el equipo con ID {id}" });
            }

            equipoExistente.Nombre = equipoActualizado.Nombre;
            equipoExistente.Presidente = equipoActualizado.Presidente;
            equipoExistente.Puntos = equipoActualizado.Puntos;

            var response = ApiResponse<Equipo>.Ok(equipoExistente, "Equipo actualizado correctamente.");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var equipo = equipos.FirstOrDefault(e => e.Id == id);
            if (equipo == null)
            {
                return NotFound(new { success = false, message = $"No se encontró el equipo con ID {id}" });
            }

            equipos.Remove(equipo);

            var response = ApiResponse<bool>.Ok(true, "Equipo eliminado correctamente.");
            return Ok(response);
        }
    }
}