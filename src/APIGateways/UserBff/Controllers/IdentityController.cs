﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBff.Dtos;
using UserBff.Services;

namespace UserBff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("Register", Name = "Register")]
        public async Task<IActionResult> Register(UserCreate user)
        {
            var status = await identityService.AddUser(user);
            return Ok(status);
        }

        [HttpPost("Login", Name = "Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await identityService.Authenticate(loginDto.Email, loginDto.Password);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("ByEmail/{email}", Name = "GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await identityService.GetUserByEmail(email);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("ById/{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await identityService.GetUserById(id);
            return Ok(user);
        }
    }
}
