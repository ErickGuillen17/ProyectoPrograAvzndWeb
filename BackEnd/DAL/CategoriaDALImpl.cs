using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CategoriaDALImpl : ICategoriaDAL
    {

        WorknetContext context;

        public CategoriaDALImpl()
        {
            context = new WorknetContext();

        }
        public bool Add(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Categoria> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Categoria Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetAll()
        {
            try
            {
                IEnumerable<Categoria> categorias;
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
                {
                    categorias = unidad.genericDAL.GetAll();
                }
                return categorias;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Categoria> entities)
        {
            throw new NotImplementedException();
        }

        public Categoria SingleOrDefault(Expression<Func<Categoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
