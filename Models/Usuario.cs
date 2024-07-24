using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoMod10.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La clave es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "La clave debe de ser entre 6 y 20 caracteres", MinimumLength = 6)]
        public string? Password { get; set; }

        [NotMapped]
        public bool KeepLoggedIn { get; set; }
    }
}
