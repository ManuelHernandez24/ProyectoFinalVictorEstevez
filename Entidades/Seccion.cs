using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Entidades
{
    public class Seccion
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Id no valido")]
        public int SeccionId { get; set; } //Nunero de identificación en la tabla

        [Required(ErrorMessage = "Debe seleccionar un maestro.")]
        public int MaestroId { get; set; } //Numero de identifiación del maestro

        [Required(ErrorMessage = "Debe seleccionar un grado.")]
        public string? Grado { get; set; } //Nombre de la seccion

        [Required(ErrorMessage = "Debe seleccionar un grupo.")]
        public string? Grupo { get; set; } //Nombre del grupo

        [Required(ErrorMessage = "Debe seleccionar área técnica.")]
        public int AreaTecnicaId { get; set; }//Nombre del area tecnica

        [Range(0, 31, ErrorMessage = "Una seccion puede tener como maximo 30 estudiantes")]
        public int CantidadEstudiantes { get; set; } // Cantidad total de estudiantes en la seccion

        [Required(ErrorMessage = "Debe ingresar una fecha.")]
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("SeccionId")]
        public virtual List<SeccionDetalle> SeccionDetalle { get; set; } = new List<SeccionDetalle>(); //En el detalle están todos los estudiantes de esa sección
    }
}