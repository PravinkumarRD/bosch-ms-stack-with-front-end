using FirstCtrlWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstCtrlWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoschCustomersController : ControllerBase
    {
        private readonly List<Customer> _customers;
        public BoschCustomersController()
        {
            _customers = new List<Customer>()
            {
                new(){CustomerId=1000,ContactName="Alisha C.",City="Mumbai"},
                new(){CustomerId=1001,ContactName="Manish Kaushik",City="Bengluru"},
                new(){CustomerId=1002,ContactName="Ali Fasal",City="Mumbai"},
            };
        }
        //[ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<Customer>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        //public IActionResult GetCustomers()
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            if (_customers.Count > 0)
            {
                return Ok(_customers);
            }
            else
            {
                return NotFound(new { ErrorMessage = "We didn't find any customers! Please try after some time!" });
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Customer> GetCustomerDetails(int id)
        {
            var customer = _customers.Find(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound(new { ErrorMessage = $"We didn't find any customer by Id {id}!" });
            }
            return Ok(customer);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Customer> Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customers.Add(customer);
                return CreatedAtAction("GetCustomerDetails", new { id = customer.CustomerId }, customer);
            }
            return BadRequest();
        }
    }
}
