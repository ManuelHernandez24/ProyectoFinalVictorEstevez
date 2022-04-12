using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Entidades
{
    public class Materia
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Id no valido")]
        public int MateriaId { get; set; } //Nunero de identificación en la tabla

        [Required(ErrorMessage = "Debe agregar un nombre a la materia.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede tener más  de {1} caracteres.")]
        public string? NombreMateria { get; set; } //Nombre de la materia

        public int VecesAsignada { get; set; } //Cantidad de maestros que tienen esta materia
    }
}