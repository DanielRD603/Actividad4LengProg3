using System.ComponentModel.DataAnnotations;

namespace Actividad4LengProg3.Models
{
    public enum Sexo { Masculino = 1, Femenino = 2, Otro = 3 }
    public enum Turno { Mañana = 1, Tarde = 2, Noche = 3 }
    // Renombrado para permitir entidad Recinto
    public enum RecintoEnum { Herrera = 1, Metropolitano = 2, Barahona = 3 }

    public class EstudianteViewModel : IValidatableObject
    {
        [Required, StringLength(20)]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Required, StringLength(80)]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Recinto")]
        public RecintoEnum? Recinto { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Correo institucional")]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(\+?1[ \-]?)?(809|829|849)[ \-]?\d{3}[ \-]?\d{4}$", ErrorMessage = "Ingrese un celular dominicano válido (809/829/849).")]
        [Display(Name = "Celular")]
        public string Celular { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(\+?1[ \-]?)?(809|829|849)[ \-]?\d{3}[ \-]?\d{4}$", ErrorMessage = "Ingrese un teléfono dominicano válido (809/829/849).")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; } = string.Empty;

        [Required, StringLength(200)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Género")]
        public Sexo? Genero { get; set; }

        [Required]
        [Display(Name = "Turno")]
        public Turno? Turno { get; set; }

        [Display(Name = "¿Está becado?")]
        public bool Becado { get; set; }

        [Range(0,100)]
        [Display(Name = "Porcentaje de beca")]
        public int? PorcentajeBeca { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Becado && (PorcentajeBeca is null || PorcentajeBeca < 0 || PorcentajeBeca > 100))
                yield return new ValidationResult("Debe indicar un porcentaje entre 0 y 100.", new[] { nameof(PorcentajeBeca) });
        }
    }
}
