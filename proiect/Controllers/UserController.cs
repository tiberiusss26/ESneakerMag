using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using proiect.Helpers.Attributes;
using proiect.Models;
using proiect.Models.DTOs.UserDTO;
using proiect.Models.Enums;
using proiect.Services.UserService;
using BCryptNet = BCrypt.Net.BCrypt;

namespace proiect.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO user)
        {
            await _userService.CreateAdmin(user);
            return Ok();
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateNewClient(UserRequestDTO user)
        {
            await _userService.CreateNewClient(user);
            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);
            if (user == null)
            {
                return BadRequest("Invalid username or password!");
            }

            return Ok();
        }


        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            var result =  _userService.DeleteByUsernameAsync(username);

            if(result == null)
            {
                return BadRequest("Username does not exist!");
            }
  

            return Ok();
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetClients(string username)
        {
            var user = await _userService.GetAllClients();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorization(Role.Admin)]
        [HttpGet("admin")]
        public IActionResult GetAllAdmin()
        {
            var admins = _userService.GetAllAdmins();
            return Ok(admins);
        }

        [Authorization(Role.NewClient,Role.LoyalClient)]
        [HttpGet("client")]
        public IActionResult GetAllUser()
        {
            var clients = _userService.GetAllClients();
            return Ok(clients);
        }
    }

}