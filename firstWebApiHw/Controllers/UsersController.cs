using Service;
using Entities;
using Microsoft.AspNetCore.Mvc;

using System.Reflection.Metadata;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace firstWebApiHw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<user>
        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] string UserName, [FromQuery] string Password)
        {
            try
            {
                User user = await _userService.getUserByUserNameAndPassword(UserName, Password);
                return user != null ? Ok(user) : Unauthorized();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        // POST api/<user>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            try { 
            User newUser = await _userService.createNewUser(user);
                return user != null ? CreatedAtAction(nameof(Get), new { id = user.UserId }, user) : BadRequest();
                

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                
                User user = await _userService.getUserById(id);
                return user != null ? Ok(user) : BadRequest("User didn't found");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<user>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User userToUpdate)
        {
            try {
                User updatedUser = await _userService.update(id,userToUpdate);
                return updatedUser != null ? Ok(updatedUser) : BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

      

        [Route("password")]
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            try { 
            var result = _userService.checkPassword(password);
            return result < 2?BadRequest( "Password is too weak") :Ok(result);
              }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}



