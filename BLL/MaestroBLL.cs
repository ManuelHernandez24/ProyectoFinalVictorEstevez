using System;
using ProyectoFinal.Entidades;
using ProyectoFinal.DAL;
using ProyectoFinal.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace ProyectoFinal.BLL
{
    public class MaestroBLL
    {

        public Contexto _contexto;

        public MaestroBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int maestroId)
        {

            bool encontrado = false;

            try
            {
                encontrado = _contexto.Maestro.Any(l => l.MaestroId == maestroId);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        public bool Guardar(Maestro maestro)
        {
            if (!Existe(maestro.MaestroId))
            {
                return Insertar(maestro);
            }
            else
            {
                return Modificar(maestro);
            }
        }

        private bool Insertar(Maestro maestro)
        {
            bool paso = false;

            try
            {
                _contexto.Maestro.Add(maestro);
                paso = _contexto.SaveChanges() > 0;
                ModificarMateria();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Maestro maestro)
        {
            bool paso = false;
            try
            {
                _contexto.Maestro.Update(maestro);
                paso = _contexto.SaveChanges() > 0;
                ModificarMateria();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public bool Eliminar(int maestroId)
        {
            bool paso = false;
            try
            {
                var maestro = _contexto.Maestro.Find(maestroId);
                if (maestro != null)
                {
                    ModificarMateriaEliminar(maestro);
                    _contexto.Maestro.Remove(maestro);
                    paso = _contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Maestro Buscar(int maestroId)
        {
            Maestro maestro;

            try
            {
                return _contexto.Maestro.Find(maestroId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Maestro> GetList(Expression<Func<Maestro, bool>> criterio)
        {
            List<Maestro> lista = new List<Maestro>();

            try
            {
                lista = _contexto.Maestro.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }


        private List<Maestro> listaMaestro { get; set; } = new List<Maestro>();
        private List<Materia> listaMateria { get; set; } = new List<Materia>();



        private void ModificarMateria()
        {
            listaMaestro = _contexto.Maestro.ToList();
            listaMateria = _contexto.Materia.ToList();
            List<int> MateriasNoEncontradas = new List<int>();
            List<int> MateriasEncontradas = new List<int>();

            foreach (var itemMateria in listaMateria)
            {
                int cantidad = 0;
                foreach (var itemMaestreo in listaMaestro)
                {
                    Maestro maestroTurno = _contexto.Maestro.Find(itemMaestreo.MaestroId);
                    Materia materia = _contexto.Materia.Find(itemMateria.MateriaId);
                    materia.VecesAsignada = 0;

                    foreach (var itemMaestroDetalle in maestroTurno.MaestroDetalle)
                    {
                        if (itemMaestroDetalle.MateriaId == itemMateria.MateriaId)
                        {
                            cantidad++;
                            materia = _contexto.Materia.Find(itemMateria.MateriaId);
                            materia.VecesAsignada = 0;
                            materia.VecesAsignada = cantidad;
                            _contexto.Update(materia);
                            _contexto.SaveChanges();

                        }
                    }
                }
            }
        }
        private void ModificarMateriaEliminar(Maestro maestro)
        {
            foreach (var item in maestro.MaestroDetalle)
            {
                Materia materia = _contexto.Materia.Find(item.MateriaId);
                materia.VecesAsignada--;
                _contexto.Update(materia);
                _contexto.SaveChanges();
            }

        }

    }
}
