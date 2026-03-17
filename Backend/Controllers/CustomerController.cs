using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
