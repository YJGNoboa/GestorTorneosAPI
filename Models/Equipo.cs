namespace GestorTorneosAPI.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Presidente { get; set; } = string.Empty;
        public int Puntos { get; set; }
    }
}