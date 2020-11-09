using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftrayNewsAPI.DL.DBContext;
using SoftrayNewsAPI.DL.Models;
using SoftrayNewsAPI.Utils;
using SoftrayNewsAPI.Services;

namespace SoftrayNewsAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                List<User> userList = _userService.GetAllUsers();

                return userList;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Get")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                User user = await _userService.GetUserById(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<User>> Insert([FromBody] User user)
        {
            try
            {
                if (user != null)
                {
                    User newUser = await _userService.InsertUser(user);
                    return Ok(newUser);
                }
                else
                {
                    return BadRequest("Desila se greska!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<User>> Update([FromBody] User userForEdit)
        {
            try
            {
                if (userForEdit != null)
                {
                    User updatedUser = await _userService.UpdateUser(userForEdit);
                    return Ok(updatedUser);
                }
                else
                {
                    return BadRequest("Desila se greska!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            try
            {
                User user = await _userService.DeleteUser(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthModel model)
        {
            var user = _userService.Authenticate(model);

            if (user == null)
                return BadRequest("Username or password is incorrect");

            return Ok(user);
        }
    }
}
