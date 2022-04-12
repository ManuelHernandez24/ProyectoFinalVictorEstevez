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
    public class MateriaBLL
    {

        public Contexto _contexto;

        public MateriaBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int materiaId)
        {

            bool encontrado = false;

            try
            {
                encontrado = _contexto.Materia.Any(l => l.MateriaId == materiaId);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        public bool Guardar(Materia materia)
        {
            if (!Existe(materia.MateriaId))
            {
                return Insertar(materia);
            }
            else
            {
                return Modificar(materia);
            }
        }

        private bool Insertar(Materia materia)
        {
            bool paso = false;

            try
            {
                _contexto.Materia.Add(materia);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Materia materia){
            bool paso = false;
            try
            {
                _contexto.Entry(materia).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            } 
            catch(Exception)
            {
            throw;
            }
            return paso;
            
        }


        public bool Eliminar(int materiaId)
        {
            bool paso = false;
            try
            {
                var materia = _contexto.Materia.Find(materiaId);
                if (materia != null)
                {
                    _contexto.Materia.Remove(materia);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Materia Buscar(int materiaId)
        {
            Materia materia;

            try
            {
                materia = _contexto.Materia.Where(p => p.MateriaId == materiaId).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return materia;
        }

        public List<Materia> GetList(Expression<Func<Materia, bool>> criterio)
        {
            List<Materia> lista = new List<Materia>();

            try
            {
                lista = _contexto.Materia.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
