using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DesafioFullStackTotvs.Models;
using DesafioFullStackTotvs.Services;
using Microsoft.AspNetCore.Authorization;

namespace DesafioFullStackTotvs.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private IUserService _userService;

        public UsersController(IUserService userService){
            _userService = userService;           
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll () {
            return _userService.GetAll().ToList();
        }

        [AllowAnonymous]
        [HttpPost("autenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Email , userParam.Password);

            if (user == null)
                return Unauthorized(new { message = "Username or password not valid" });

            return Ok(user);
        }


        [HttpGet ("{id}", Name = "GetUser")]
        public ActionResult<User> GetById (long id) {
            var item = _userService.GetById(id);
            if(item == null){
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create (User item) {
            _userService.Add(item);           
            return CreatedAtRoute ("GetUser", new { id = item.UserID }, item);
        }

        [HttpPut ("{id}")]
        public IActionResult Update (long id, User item) {
            _userService.Update(id, item);
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (long id) {
            _userService.Delete(id);
            return NoContent ();
        }
    }
}