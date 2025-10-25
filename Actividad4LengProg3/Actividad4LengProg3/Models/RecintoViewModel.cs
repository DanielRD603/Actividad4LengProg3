using System.ComponentModel.DataAnnotations;

namespace ActividadUnidad2.Models
{
    public class RecintoViewModel
    {
        [Required(ErrorMessage = "El c�digo es obligatorio")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La direcci�n es obligatoria")]
        [StringLength(100)]
        public string Direccion { get; set; } = string.Empty;
    }
}
