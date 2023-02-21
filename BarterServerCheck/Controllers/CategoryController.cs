using BarterServer.Controllers;
using BL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace BarterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryBL _categoryBL;

        public CategoryController(ICategoryBL categoryBL)
        {
            _categoryBL = categoryBL;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public ActionResult<List<Opinion>> GetAllCategories()
        {
            try
            {
                return Ok(_categoryBL.GetAllCategories());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public ActionResult<CategoryDTO> GetCategoryById(int id)
        {
            CategoryDTO category = _categoryBL.GetCategoryById(id);
            if(category == null) 
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [Route("AddCategory")]
        public bool AddCategory([FromBody] CategoryDTO category)
        {
            var x = _categoryBL.AddCategory(category);
            return x;
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        public bool DeleteCategory(int id)
        {
            return _categoryBL.DeleteCategory(id);
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public bool UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            return _categoryBL.UpdateCategory(id, category);
        }
    }
}





