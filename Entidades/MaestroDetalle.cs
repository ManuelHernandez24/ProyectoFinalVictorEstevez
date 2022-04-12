using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Entidades
{

    public partial class MaestroDetalle
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Id no valido")]
        public int MaestroDetalleId { get; set; }
        public int MaestroId { get; set; }
        public int MateriaId { get; set; }

        public MaestroDetalle(int materiaId)
        {
            MateriaId = materiaId;
        }

    }
}