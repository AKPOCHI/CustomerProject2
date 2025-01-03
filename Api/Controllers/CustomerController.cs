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
      

        public CustomerController()
        {
            
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
            using (var Context = new AppDbContext())
            {
                Context.Customers.Add(customer);
                Context.SaveChanges();

            }
            return "customer added successfully";
        }

    }
}
