using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindApiDemo.Models;

namespace NorthwindApiDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        [HttpGet("{id}/orders")]
        public IActionResult GetOrders(int id)//CustomerID
        {
            var customer = Repository.Instance.Customers.FirstOrDefault(x => x.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer.Orders);
        }

        [HttpGet("{CustomerID}/orders/{OrderId}", Name = "GetOrder")]
        public IActionResult GetOrder(int CustomerID, int OrderId)
        {
            var customer = Repository.Instance.Customers.FirstOrDefault(x => x.CustomerID == CustomerID);
            if (customer == null)
            {
                return NotFound();
            }

            var order = customer.Orders.FirstOrDefault(x => x.OrderId == OrderId);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("{CustomerID}/orders")]
        public IActionResult CreateOrder(int CustomerID, [FromBody] OrdersForCreationDTO order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = Repository.Instance.Customers.FirstOrDefault(x => x.CustomerID == CustomerID);


            if (customer == null)
            {
                return NotFound();
            }

            var maxOrderId = Repository.Instance.Customers.SelectMany(x => x.Orders).Max(o => o.OrderId);

            var finalOrder = new OrdersDTO()
            {
                OrderId = maxOrderId++,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            };
            customer.Orders.Add(finalOrder);

            return CreatedAtRoute("GetOrder",
                new
                {
                    CustomerID = CustomerID,
                    OrderId = finalOrder.OrderId
                }, finalOrder);
        }

        [HttpPut("{customerId}/orders/{orderId}")]
        public IActionResult UpdateOrder(int CustomerID, int OrderId, [FromBody] OrdersForUpdateDTO order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = Repository.Instance.Customers.FirstOrDefault(c => c.Id == CustomerID);
            if (customer == null)
            {
                return NotFound();
            }

            var orderFromRepository = customer.Orders.FirstOrDefault(o => o.OrderId == OrderId);
            if (orderFromRepository == null)
            {
                return NotFound();
            }

            orderFromRepository.CustomerId = order.CustomerId;
            orderFromRepository.EmployeeId = order.EmployeeId;
            orderFromRepository.OrderDate = order.OrderDate;
            orderFromRepository.RequiredDate = order.RequiredDate;
            orderFromRepository.ShippedDate = order.ShippedDate;
            orderFromRepository.ShipVia = order.ShipVia;
            orderFromRepository.Freight = order.Freight;
            orderFromRepository.ShipName = order.ShipName;
            orderFromRepository.ShipAddress = order.ShipAddress;
            orderFromRepository.ShipCity = order.ShipCity;
            orderFromRepository.ShipRegion = order.ShipRegion;
            orderFromRepository.ShipPostalCode = order.ShipPostalCode;
            orderFromRepository.ShipCountry = order.ShipCountry;
            return NoContent();

        }

    }
}