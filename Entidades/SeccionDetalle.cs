using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinal.Entidades;

namespace ProyectoFinal.Entidades
{

    public partial class SeccionDetalle
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Id no valido")]
        public int SeccionId { get; set; }
        public int EstudianteId { get; set; }

        public SeccionDetalle(int estudianteId)
        {
            EstudianteId = estudianteId;
        }
    }
}