using BL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryUserController : ControllerBase
    {
        public ICategoryUserBL _categoryUser;
        public CategoryUserController(ICategoryUserBL categoryUserBL)
        {
            _categoryUser = categoryUserBL;
        }
        [HttpGet]
        [Route("getUserByCategoryId/{id}")]
        public ActionResult<List<CategoryUser>> GetUserByCategoryId(int id)
        {
            try
            {
                return Ok(_categoryUser.GetUserByCategoryId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
