using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindApiDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        [HttpGet("")]
        public IActionResult GetCustomers()
        {
            return new JsonResult(Repository.Instance.Customers);

        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int Id)
        {
            var result = Repository.Instance.Customers.FirstOrDefault(x => x.CustomerID == Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok( result);  
            //return new JsonResult(result);
        }
    }
}