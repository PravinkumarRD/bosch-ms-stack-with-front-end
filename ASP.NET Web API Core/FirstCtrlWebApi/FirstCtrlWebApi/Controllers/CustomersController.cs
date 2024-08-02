using FirstCtrlWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCtrlWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly List<Customer> _customers;
        public CustomersController()
        {
            _customers = new List<Customer>()
            {
                new(){CustomerId=1000,ContactName="Alisha C.",City="Mumbai"},
                new(){CustomerId=1001,ContactName="Manish Kaushik",City="Bengluru"},
                new(){CustomerId=1002,ContactName="Ali Fasal",City="Mumbai"},
            };
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customers;
        }
        [HttpGet("{id:int}")]
        public Customer Get(int id)
        {
            return _customers.Find(c => c.CustomerId == id);
        }
        [HttpGet("{city:alpha}")]
        public IEnumerable<Customer> Get(string city)
        {
            return _customers.Where(c => c.City == city);
        }
        [HttpGet("{city:alpha}/{startsWith:alpha}")]
        public IEnumerable<Customer> Get(string city, string startsWith)
        {
            return _customers.Where(c => c.City == city && c.ContactName.StartsWith(startsWith));
        }
        [HttpPost]
        public IEnumerable<Customer> Post(Customer customer)
        {
            _customers.Add(customer);
            return _customers;
        }
        [HttpPut]
        public IEnumerable<Customer> Put(int id, Customer customer)
        {
            var existingCustomer = _customers.Find(c => c.CustomerId == id);
            existingCustomer.ContactName = customer.ContactName;
            existingCustomer.City = customer.City;
            return _customers;
        }
        [HttpDelete]
        public IEnumerable<Customer> Delete(int id)
        {
            var existingCustomer = _customers.Find(c => c.CustomerId == id);
            if (existingCustomer != null)
            {
                _customers.Remove(existingCustomer);
            }
            return _customers;
        }
    }
}
