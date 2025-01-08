using Data;
using Data.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-user")]
        public string CreateUser([FromBody] CreateUserDto createUserDto)
        {

            var customer = new Customer()
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email,
                PassWord = createUserDto.Password
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return "customer added successfully";
        }

    }
}
