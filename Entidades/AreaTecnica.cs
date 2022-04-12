using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Entidades
{
    public class AreaTecnica
    {

        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Id no valido")]
        public int AreaTecnicaId { get; set; } //Nunero de identificación en la tabla

        [Required(ErrorMessage = "Debe agregar un nombre al área técnica")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos {1} caracteres")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más  de {1} caracteres")]
        public string? NombreAreaTecnica { get; set; } //Nombre del area tecnica
    }
}