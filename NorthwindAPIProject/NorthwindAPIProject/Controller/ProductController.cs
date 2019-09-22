using Microsoft.AspNetCore.Mvc;
using NorthwindAPIProject.DTO;
using NorthwindAPIProject.Model;
using NorthwindAPIProject.Services;
using System.Collections.Generic;

namespace NorthwindAPIProject.Controller
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : ControllerBase 
    {
        IRepository repository;

        public ProductController(IRepository repository)
        {
            this.repository = repository;
        }
      

        [HttpGet("getProductos")]
        public IActionResult GetProductos()
        {
            List<Products> lstProductos = repository.GetProducts();
            return Ok(lstProductos);
        }

        [HttpGet("getShippers")]
        public IActionResult GetShippers()
        {
            List<Shippers> lstShippers = repository.GetShippers();
            return Ok(lstShippers);
        }

        [HttpPost("insertProducto")]
        public IActionResult InsertProducto([FromBody] ShipperDTO oShipper)
        {
            var a = oShipper;
            return Ok(a);
        }
        /*
         Shippers
         */

    }
}