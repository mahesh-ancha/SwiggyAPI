using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwiggyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserContext _userContext;

        public UserController(IConfiguration configuration, UserContext userContext)
        {
            _config = configuration;
            _userContext = userContext;
        }
        [AllowAnonymous]
        [HttpPost("createUser")]
        public IActionResult CreateUser(User user)
        {
            if (_userContext.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return Ok("Already Existed");
            }
            user.MemberSince = DateTime.Now;
            _userContext.Users.Add(user);
            _userContext.SaveChanges();

            return Ok("Success");
        }

        [AllowAnonymous]
        [HttpPost("loginUser")]
        public IActionResult LoginUser(Login login)
        {
            var useravailable = _userContext.Users.Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
            if (useravailable != null)
            {
                return Ok("Success");
            }
            return Ok("Failure");
        }
    }
}

//https://localhost:44367/