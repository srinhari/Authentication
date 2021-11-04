using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UserService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IList<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Ram",
                Email = "Ram@abc.com"

            },
            new User {
                Id = 2,
                Name = "Shyam",
                Email = "Shyam@def.com"

            },
            new User {
                Id = 3,
                Name = "Shiva",
                Email = "Shiva@ghi.com"

            }
        };

        [HttpGet("/users")]
        public IActionResult Index()
        {
            return Ok(_users);
        }
    }
}
