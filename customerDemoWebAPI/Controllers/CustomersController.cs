using customerDemoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace customerDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public static List<Customer> customers = new()
        {
            new Customer {id = 1, FirstName = "Krishn", LastName = "Mehta", City = "Jamnagar"},
            new Customer {id = 2, FirstName =  "Tom", LastName = "Cruise", City = "New York"},
            new Customer {id = 3, FirstName =  "John", LastName = "Parker", City = "Mumbai"},
        };

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = customers.Find(x => x.id== id);
            if(customer == null)
            {
                return NotFound("Cutomer not found");  
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            customers.Add(customer);
            return Ok(customers);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var customerInList = customers.Find(x =>x.id== customer.id);
            if(customerInList == null)
            {
                return NotFound("Invalid ID");
            }
            customerInList.FirstName = customer.FirstName;
            customerInList.LastName = customer.LastName;
            customerInList.City = customer.City;
            return Ok(customerInList);

        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customers.Find(x => x.id== id);
            if(customer == null)
            {
                return NotFound("Invalid Detail");
            }
            customers.Remove(customer);
            return Ok(customers);
        }
    }
}
