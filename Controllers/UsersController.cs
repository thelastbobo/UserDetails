using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserDetails.Models;
using UserDetails.Services;

namespace UserDetails.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;

        public UsersController(JsonFileUserService userService, IMapper mapper)
        {
            this.UserService = userService;
            this.mapper = mapper;
        }

        public JsonFileUserService UserService { get; }

        [Route("users")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(UserService.GetUsers());
            }
            catch
            {
                return BadRequest("Failed to get users.");
            }
        }

        [Route("user")]
        [HttpGet]
        public IActionResult GetById([FromQuery]long id)
        {
            try
            {
                return Ok(UserService.GetUserById(id));
            }
            catch
            {
                return BadRequest($"Failed to get user with id:{id}.");
            }
        }

        [Route("user/{id}")]
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UserService.UpdateUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("The user hasn't been updated");
            }
        }

        [Route("user")]
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                UserService.UpdateUser(user);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("The user hasn't been updated");
            }
        }
    }
}