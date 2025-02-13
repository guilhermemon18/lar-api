using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.dto;
using Backend.Api.Models;
using Backend.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignupDto signupDto)
        {
            User user = _userService.Signup(signupDto);
            return Ok(user);
        }

        [HttpPost("signin")]
        public IActionResult Signin([FromBody] SigninDto signinDto)
        {
            TokenDto token = _userService.Signin(signinDto);
            return Ok(token);
        }


        [HttpGet]
        public IActionResult FindAll()
        {
            var users = _userService.FindAll();
            return Ok(users);
        }

    }
}