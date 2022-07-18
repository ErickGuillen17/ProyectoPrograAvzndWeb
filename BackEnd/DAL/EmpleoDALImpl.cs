﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class EmpleoDALImpl : IEmpleoDAL
    {

        WorknetContext context;

        public EmpleoDALImpl()
        {
            context = new WorknetContext();

        }

        public bool Add(Empleo entity)
        {
            try
            {
                //sumar o calcular 

                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Empleo> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empleo> Find(Expression<Func<Empleo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Empleo Get(int id)
        {
            try
            {
                Empleo empleo;
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    empleo = unidad.genericDAL.Get(id);
                }
                return empleo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Empleo> Get()
        {
            try
            {
                IEnumerable<Empleo> empleos;
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    empleos = unidad.genericDAL.GetAll();
                }
                return empleos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Empleo> GetAll()
        {
            try
            {
                IEnumerable<Empleo> empleos;
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    empleos = unidad.genericDAL.GetAll();
                }
                return empleos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Empleo entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Empleo> entities)
        {
            throw new NotImplementedException();
        }

        public Empleo SingleOrDefault(Expression<Func<Empleo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Empleo empleo)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Empleo> unidad = new UnidadDeTrabajo<Empleo>(context))
                {
                    unidad.genericDAL.Update(empleo);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }


    }
}
