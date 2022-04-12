using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Entidades;

namespace ProyectoFinal.DAL
{
    public class Contexto : DbContext
    {

        public DbSet<Maestro> Maestro { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<AreaTecnica> AreaTecnica { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Seccion> Seccion { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>().HasData(new Materia
            {
                MateriaId = 1,
                NombreMateria = "Lengua Española"
            });
            modelBuilder.Entity<Materia>().HasData(new Materia
            {
                MateriaId = 2,
                NombreMateria = "Matemática"
            });
            modelBuilder.Entity<Materia>().HasData(new Materia
            {
                MateriaId = 3,
                NombreMateria = "Ciencias Naturales"
            });
            modelBuilder.Entity<Materia>().HasData(new Materia
            {
                MateriaId = 4,
                NombreMateria = "Ciencias Sociales"
            });

            modelBuilder.Entity<AreaTecnica>().HasData(new AreaTecnica
            {
                AreaTecnicaId = 1,
                NombreAreaTecnica = "Académico"
            });
            modelBuilder.Entity<AreaTecnica>().HasData(new AreaTecnica
            {
                AreaTecnicaId = 2,
                NombreAreaTecnica = "Informática"
            });

            modelBuilder.Entity<AreaTecnica>().HasData(new AreaTecnica
            {
                AreaTecnicaId = 3,
                NombreAreaTecnica = "Contabilidad"
            });

        }
    }
}

