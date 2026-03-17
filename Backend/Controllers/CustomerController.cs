using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly BasicDbContext _db;

        public CustomerController(BasicDbContext context)
        {
            _db = context;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Customer>> GetAll()
        {
            if (_db.Customers == null)
            {
                return NotFound();
            }
            return Ok(new Customer().GetAll(_db));
        }

        [HttpPost("Create")]
        public ActionResult<Customer> Create(Customer customer)
        {
            if (customer == null )
            {
                return BadRequest();
            }
            return Ok(customer.Create(_db));
        }

        [HttpPut("{id}")]
        public ActionResult<Customer> Update(Customer customer , int id) {
            if (customer == null)
            {
                return BadRequest();
            }
            return Ok(customer.Update(_db, id));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            Customer customer = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Delete();
            _db.SaveChanges();
            return Ok(customer);
        }
    }
}
