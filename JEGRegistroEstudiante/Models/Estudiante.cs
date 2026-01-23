using System.ComponentModel.DataAnnotations;
namespace JEGRegistroEstudiante.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligarotio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        public int edad { get; set; }














    }
}
