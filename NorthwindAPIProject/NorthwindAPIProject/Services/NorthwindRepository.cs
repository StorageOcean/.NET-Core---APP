using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindAPIProject.Model;

namespace NorthwindAPIProject.Services
{
    public class NorthwindRepository : IRepository
    {

        private readonly NorthwindContext _contexto;

        public NorthwindRepository(NorthwindContext contexto)
        {
            this._contexto = contexto;
        }

        public List<Products> GetProducts()
        {
           
            var lstProductos = _contexto.Products.ToList();
            return lstProductos;
        }

        public List<Shippers> GetShippers()
        {
            var lstShippers = _contexto.Shippers.ToList();
            return lstShippers;
        }
}
}