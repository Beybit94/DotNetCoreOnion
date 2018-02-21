using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Service;

namespace test.Controllers {
    [Route ("api/[controller]")]
    public class UserController : Controller {
        private readonly IUserService userService;

        public UserController (IUserService userService) {
            this.userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get () {
            // User user=new User{
            //     name="admin",
            //     login="admin",
            //     pass="123456",
            //     ModifiedDate=DateTime.Now
            // };
            // userService.InsertUser(user);

            return userService.GetUsers ();
        }

        [HttpGet("{id}",Name="GetUserById")]
        public User Get (int id) {
            return userService.GetUser (id);
        }

        [HttpPost]
        public IActionResult Create ([FromBody] User user) {
            if (user == null) {
                return BadRequest ();
            }

            user.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString ();
            user.ModifiedDate = DateTime.Now;
            userService.InsertUser (user);

            return Ok ();
        }

        [HttpPut]
        public IActionResult Edit ([FromBody] User user) {
            if (user == null || user.Id == 0) {
                return BadRequest ();
            }

            var item = userService.GetUser (user.Id);
            if (item == null) {
                return NotFound ();
            }

            item.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString ();
            item.ModifiedDate = DateTime.Now;
            item.name = user.name;
            item.login = user.login;
            item.pass = user.pass;
            userService.UpdateUser (item);

            return Ok ();
        }

        [HttpDelete]
        public IActionResult Delete (int id) {
            var item = userService.GetUser (id);
            if (item == null) {
                return NotFound ();
            }

            userService.DeleteUser (id);
            return NoContent ();
        }
    }
}