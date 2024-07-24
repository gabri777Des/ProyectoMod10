using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMod10.Models
{
    public class Actividad
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(50, ErrorMessage = "El título no debe contener mas de 50 caracteres")]
        public string? Título { get; set; }
        // Título con tildeeeeeeee
        

        public string? Tarea { get; set; }
    }
}
