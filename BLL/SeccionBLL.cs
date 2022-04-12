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
    public class SeccionBLL
    {

        public Contexto _contexto;

        public SeccionBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int seccionId)
        {

            bool encontrado = false;

            try
            {
                encontrado = _contexto.Seccion.Any(l => l.SeccionId == seccionId);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        public bool Guardar(Seccion seccion)
        {
            if (!Existe(seccion.SeccionId))
            {
                return Insertar(seccion);
            }
            else
            {
                return Modificar(seccion);
            }
        }

        private bool Insertar(Seccion seccion)
        {
            bool paso = false;
            int maestroId = 0;

            try
            {
                maestroId = seccion.MaestroId;
                _contexto.Seccion.Add(seccion);
                paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Seccion seccion)
        {
            bool paso = false;
            try
            {
                _contexto.Seccion.Update(seccion);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private MaestroBLL maestro { get; set; }
        private List<Seccion> listaSecciones { get; set; } = new List<Seccion>();

        public bool Eliminar(int seccionId)
        {
            bool paso = false;
            int maestroId = 0;
            try
            {
                var seccion = _contexto.Seccion.Find(seccionId);
                if (seccion != null)
                {
                    _contexto.Seccion.Remove(seccion);
                    maestroId = seccion.MaestroId;
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Seccion Buscar(int seccionId)
        {
            Seccion seccion;

            try
            {
                seccion = _contexto.Seccion.Include(x => x.SeccionDetalle).Where(p => p.SeccionId == seccionId).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return seccion;
        }
        public Seccion BuscarSeccion(int id)
        {
            Seccion seccionEncontrada = _contexto.Seccion.Find(id);
            return seccionEncontrada;
        }

        public bool ComprobarExistenciaSeccion(string grado, string grupo, int areaTecnicaId)
        {
            bool encontrado = false;
            List<Seccion> listaSeccion = GetList(p => true);
            foreach (var itemSeccion in listaSeccion)
            {
                if ($"{itemSeccion.Grado} {itemSeccion.Grupo} {itemSeccion.AreaTecnicaId}" == $"{grado} {grupo} {areaTecnicaId}")
                {
                    encontrado = true;
                    break;
                }
            }
            return encontrado;
        }


        public List<Seccion> GetList(Expression<Func<Seccion, bool>> criterio)
        {
            List<Seccion> lista = new List<Seccion>();

            try
            {
                lista = _contexto.Seccion.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
