using NorthwindAPIProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPIProject.Services
{
    public interface IRepository
    {
        List<Products> GetProducts();
        List<Shippers> GetShippers();
    }
}
