using System.ComponentModel.DataAnnotations;

namespace GestorTorneosAPI.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del presidente es obligatorio")]
        public string Presidente { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Los puntos deben estar entre 0 y 100")]
        public int Puntos { get; set; }
    }
}