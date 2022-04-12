using System;
using ProyectoFinal.Entidades;
using ProyectoFinal.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace ProyectoFinal.BLL
{
    public class EstudianteBLL
    {

        public Contexto _contexto;

        public EstudianteBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int estudianteId)
        {

            bool encontrado = false;

            try
            {
                encontrado = _contexto.Estudiante.Any(l => l.EstudianteId == estudianteId);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        public bool Guardar(Estudiante estudiante)
        {
            if (!Existe(estudiante.EstudianteId))
            {
                return Insertar(estudiante);
            }
            else
            {
                return Modificar(estudiante);
            }
        }

        private bool Insertar(Estudiante estudiante)
        {
            bool paso = false;

            try
            {
                _contexto.Estudiante.Add(estudiante);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Estudiante estudiante)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(estudiante).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }


        public bool Eliminar(int estudianteId)
        {
            bool paso = false;
            try
            {
                var estudiante = _contexto.Estudiante.Find(estudianteId);
                if (estudiante != null)
                {
                    _contexto.Estudiante.Remove(estudiante);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Estudiante Buscar(int estudianteId)
        {
            Estudiante estudiante;

            try
            {
                estudiante = _contexto.Estudiante.Where(p => p.EstudianteId == estudianteId).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return estudiante;
        }

        public List<Estudiante> GetList(Expression<Func<Estudiante, bool>> criterio)
        {
            List<Estudiante> lista = new List<Estudiante>();

            try
            {
                lista = _contexto.Estudiante.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
