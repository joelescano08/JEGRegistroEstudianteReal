using System.ComponentModel.DataAnnotations;

namespace JEGRegistroEstudiante.Models
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El aula es obligatoria")]
        public string Aula { get; set; }

        [Required(ErrorMessage = "Los créditos son obligatorios")]
        public int Creditos { get; set; }

    }
}
