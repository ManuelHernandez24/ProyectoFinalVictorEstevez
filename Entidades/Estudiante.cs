using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Entidades
{
    public class Estudiante
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Id no valido")]
        public int EstudianteId { get; set; } //Nunero de identificación en la tabla

        //Datos del estudiante
        [Required(ErrorMessage = "Debe agregar los nombres del estudiante.")]
        [MinLength(3, ErrorMessage = "Los nombres deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los nombres no pueden tener más  de {1} caracteres.")]
        public string? Nombres { get; set; } // Nombres del estudiante(Sin apellidos)

        [Required(ErrorMessage = "Debe agregar los apellidos del estudiante.")]
        [MinLength(3, ErrorMessage = "Los apellidos deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los apellidos no pueden tener más  de {1} caracteres.")]
        public string? Apellidos { get; set; } // Apellidos del estudiante(Sin nombres)

        [Required(ErrorMessage = "Debe seleccionar un sexo.")]
        public string? Sexo { get; set; } // Sexo del estudiante

        [Required(ErrorMessage = "Debe seleccionar una nacionalidad.")]
        public string? Nacionalidad { get; set; } // Nacionalidad del estudiante

        [Required(ErrorMessage = "Debe seleccionar una fecha.")]
        public DateTime FechaNacimiento { get; set; } // Fecha de Nacimiento del estudiante

        [Required(ErrorMessage = "Debe agregar una dirección para el estudiante.")]
        [MinLength(10, ErrorMessage = "La direecion deben tener al menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "La direecion no pueden tener más  de {1} caracteres.")]
        public string? Direccion { get; set; } // Direccion del estudiante

        [Required(ErrorMessage = "Debe agregar un número teléfonico para el estudiante.")]
        [Phone(ErrorMessage = "El número teléfonico no es valido.")]
        [MinLength(10, ErrorMessage = "Número teléfonico muy corto.")]
        [MaxLength(10, ErrorMessage = "Número teléfonico muy largo.")]
        public string? Telefono { get; set; } // Numero telefonico del estudiante

        [Required(ErrorMessage = "No puede dejar el campo email vacio.")]
        [EmailAddress(ErrorMessage = "El Email no es valido")]
        public string? Email { get; set; } // Correo electronica del estudiante

        [Required(ErrorMessage = "Debe seleccionar un area técnica.")]
        public int AreaTecnicaId { get; set; } //Id del area tecnica        


        // Un estudiante puede inscribirse sin los datos de los padres.


        //Datos de la madre
        [Phone(ErrorMessage = "Numero de identificación no valido..")]
        [Required(ErrorMessage = "Debe ingresar el numero de cédula.")]
        [MinLength(11, ErrorMessage = "Número muy corto.")]
        [MaxLength(11, ErrorMessage = "Número muy largo.")]

        public string? NumeroIdentificacionMadre { get; set; } //Numero de cedula de la madre

        [Required(ErrorMessage = "Debe agregar los nombres de la madre.")]
        [MinLength(3, ErrorMessage = "Los nombres deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los nombres no pueden tener más  de {1} caracteres.")]

        public string? NombresMadre { get; set; } // Nombres de la madre(Sin apellidos)

        [Required(ErrorMessage = "Debe agregar los apellidos de la madre.")]
        [MinLength(3, ErrorMessage = "Los apellidos deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los apellidos no pueden tener más  de {1} caracteres.")]
        public string? ApellidosMadre { get; set; } //Apellidos de la madre (Sin nombes)

        [Required(ErrorMessage = "Debe agregar un número telefonico.")]
        [Phone(ErrorMessage = "El número teléfonico no es valido.")]
        [MinLength(10, ErrorMessage = "Número teléfonico muy corto.")]
        [MaxLength(10, ErrorMessage = "Número teléfonico muy largo.")]
        public string? TelefonoMadre { get; set; } //Numero telefonico de la madre


        //Datos del padre
        [Required(ErrorMessage = "Debe ingresar el numero de cédula.")]
        [Phone(ErrorMessage = "Numero de identificación no valido..")]
        [MinLength(11, ErrorMessage = "Número muy corto.")]
        [MaxLength(11, ErrorMessage = "Número muy largo.")]
        public string? NumeroIdentificacionPadre { get; set; } //Numero de cedula del padre

        [Required(ErrorMessage = "Debe agregar los nombres del padre.")]
        [MinLength(3, ErrorMessage = "Los nombres deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los nombres no pueden tener más  de {1} caracteres.")]
        public string? NombresPadre { get; set; } // Nombres del padre(Sin apellidos)

        [Required(ErrorMessage = "Debe agregar los apellidos del padre.")]
        [MinLength(3, ErrorMessage = "Los apellidos deben tener al menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Los apellidos no pueden tener más  de {1} caracteres.")]
        public string? ApellidosPadre { get; set; } //Apellidos del padre (Sin nombes)

        [Required(ErrorMessage = "Debe agregar un número telefonico.")]
        [Phone(ErrorMessage = "El número teléfonico no es valido.")]
        [MinLength(10, ErrorMessage = "Número teléfonico muy corto.")]
        [MaxLength(10, ErrorMessage = "Número teléfonico muy largo.")]
        public string? TelefonoPadre { get; set; } //Numero telefonico del padre

    }
}