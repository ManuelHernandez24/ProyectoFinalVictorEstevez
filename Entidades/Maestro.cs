using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProyectoFinal.Entidades;


namespace ProyectoFinal.Entidades
{
    public class Maestro
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Id no valido")]
        public int MaestroId { get; set; } //Nunero de identificación en la tabla

        [Phone(ErrorMessage = "Numero de identificación no valido..")]
        [MinLength(11, ErrorMessage = "Número muy corto.")]
        [MaxLength(11, ErrorMessage = "Número muy largo.")]
        public string? NumeroIdentificacion { get; set; } //Numero de cedula

        [Required(ErrorMessage = "Debe agregar los nombres del maestro.")]
        [MinLength(3, ErrorMessage = "Los nombres deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los nombres no pueden tener más  de {1} caracteres.")]
        public string? Nombres { get; set; } // Nombres del maestro(Sin apellidos)

        [Required(ErrorMessage = "Debe agregar los apellidos del maestro.")]
        [MinLength(3, ErrorMessage = "Los apellidos deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los apellidos no pueden tener más  de {1} caracteres.")]
        public string? Apellidos { get; set; } // Apellidos del maestro(Sin nombres)

        [Required(ErrorMessage = "Debe agregar un sexo para el maestro.")]
        public string? Sexo { get; set; } // Sexo del maestro

        [Required(ErrorMessage = "Debe agregar una nacionalidad para el maestro.")]
        public string? Nacionalidad { get; set; } // Nacionalidad del maestro

        [Required(ErrorMessage = "Debe agregar una fecha de nacimiento para el maestro.")]
        public DateTime FechaNacimiento { get; set; } // Fecha de Nacimiento del maestro


        [Required(ErrorMessage = "Debe agregar una dirección para el maestro.")]
        [MinLength(10, ErrorMessage = "La direecion deben tener al menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "La direecion no pueden tener más  de {1} caracteres.")]
        public string? Direccion { get; set; } // Direccion del maestro

        [Required(ErrorMessage = "Debe agregar un número teléfonico para el maestro.")]
        [Phone(ErrorMessage = "El número teléfonico no es valido.")]
        [MinLength(10, ErrorMessage = "Número teléfonico muy corto.")]
        [MaxLength(10, ErrorMessage = "Número teléfonico muy largo.")]
        public string? Telefono { get; set; } // Numero telefonico del maestro


        [Required(ErrorMessage = "No puede dejar el campo email vacio.")]
        [EmailAddress(ErrorMessage = "El Email no es valido")]
        public string? Email { get; set; } // Correo electronica del maestro

        public int CantidadMaterias { get; set; } //Cantidad de asignaturas que está impartieno el maestro actualmente

        [ForeignKey("MaestroId")]

        public virtual List<MaestroDetalle> MaestroDetalle { get; set; } = new List<MaestroDetalle>(); //En el detalle están las asignaturas que imparte el maestro
    }
}