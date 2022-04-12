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
    public class AreaTecnicaBLL
    {

        public Contexto _contexto;

        public AreaTecnicaBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int areaTecnicaId)
        {

            bool encontrado = false;

            try
            {
                encontrado = _contexto.AreaTecnica.Any(l => l.AreaTecnicaId == areaTecnicaId);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        public bool Guardar(AreaTecnica areaTecnica)
        {
            if (!Existe(areaTecnica.AreaTecnicaId))
            {
                return Insertar(areaTecnica);
            }
            else
            {
                return Modificar(areaTecnica);
            }
        }

        private bool Insertar(AreaTecnica areaTecnica)
        {
            bool paso = false;

            try
            {
                _contexto.AreaTecnica.Add(areaTecnica);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(AreaTecnica areaTecnica){
            bool paso = false;
            try
            {
                _contexto.Entry(areaTecnica).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            } 
            catch(Exception)
            {
            throw;
            }
            return paso;
            
        }


        public bool Eliminar(int areaTecnicaId)
        {
            bool paso = false;
            try
            {
                var areaTecnica = _contexto.AreaTecnica.Find(areaTecnicaId);
                if (areaTecnica != null)
                {
                    _contexto.AreaTecnica.Remove(areaTecnica);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public AreaTecnica Buscar(int areaTecnicaId)
        {
            AreaTecnica areaTecnica;

            try
            {
                areaTecnica = _contexto.AreaTecnica.Where(p => p.AreaTecnicaId == areaTecnicaId).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return areaTecnica;
        }

        public List<AreaTecnica> GetList(Expression<Func<AreaTecnica, bool>> criterio)
        {
            List<AreaTecnica> lista = new List<AreaTecnica>();

            try
            {
                lista = _contexto.AreaTecnica.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
