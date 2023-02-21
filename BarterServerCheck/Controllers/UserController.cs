using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BL;
using DTO;
using DAL.Models;

namespace BarterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            List<UserDTO> users = _userBL.GetAllUsers();
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public ActionResult<UserDTO> GetUserById(int id)
        {
            UserDTO user = _userBL.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost]
        [Route("AddUser")]
        public bool AddUser([FromBody] UserCreateRequest userr)
        {
            var x = _userBL.AddUser(userr);
            return x;
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public bool DeleteUser(int id)
        {
            return _userBL.DeleteUser(id);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public ActionResult<bool> UpdateUser(int id, [FromBody] UserDTO user)
        {
            if (user.Id != id)

                return StatusCode(400, "");
            return Ok(_userBL.UpdateUser(id, user));
        }

        [HttpGet]
        [Route("GetUserByEmailAndPassword/{email}/{password}")]
        public ActionResult<UserDTO> GetUserByEmailEndPassword(string email, string password)
        {
            UserDTO user = _userBL.GetUserByEmailAndPassword(email, password);
            if (user == null)
                return StatusCode(400, "id not found");
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public ActionResult<UserDTO> GetUserByEmail(string email)
        {
            UserDTO user = _userBL.GetUserByEmail(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}

