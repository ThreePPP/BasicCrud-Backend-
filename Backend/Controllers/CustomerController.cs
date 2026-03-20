using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

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
                return NotFound(new { code = 400 , message = "Not have Database"});
            }
            Customer customer = new Customer();
            customer.GetAll(_db);
            return Ok(new { code = 200 , message = "GetAll Success" , data = customer});
        }

        [HttpGet("GetbyId")]
        public ActionResult<List<Customer>> GetbyId(int id)
        {
            Customer customer = _db.Customers.FirstOrDefault(c => c.Id == id && c.IsDelete == false);
            if ( customer == null) 
            {
                return BadRequest(new { code = 400, message = "Not found Id or already Delete" });
            }
            return Ok(new { code = 200 , message = "GetId Success" , data = customer });           
        }

        [HttpPost("Create")]
        public ActionResult<Customer> Create(Customer customer)
        {
            customer.Create(_db);
            if (customer == null )
            {
                return BadRequest(new { code = 200 , message = "Not found Id" });
            }
            return Ok(new { code = 200 , message = "Create Success" , data = customer});
        }

        [HttpPut("{id}")]
        public ActionResult<Customer> Update(Customer customer , int id) 
        {
            customer.Update(_db, id);
            if (customer == null)
            {
                return BadRequest(new { code = 400, message = "Not found Id" });
            }
            return Ok(new { code = 200 , message = "Update Success" , data = customer });
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            Customer customer = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null || customer.IsDelete == true)
            {
                return BadRequest(new { code = 404, message = "Not found Id or already Delete" });
            }
            customer.Delete();
            _db.SaveChanges();
            return Ok(new { code = 200 , message = "Delete Success" , data = customer} );
        }
    }
}