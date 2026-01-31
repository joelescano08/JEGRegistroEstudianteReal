using System.ComponentModel.DataAnnotations;

namespace JEGRegistroEstudiante.Models
{
    public class TiposPuntos
    {
        [Key]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El valor de puntos es obligatorio")]
        public int ValorPuntos { get; set; }

        [Required(ErrorMessage = "El color es obligatorio")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "El icono es obligatorio")]
        public string Icono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Activo { get; set; }
    }
}
