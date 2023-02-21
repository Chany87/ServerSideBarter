using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BL;

namespace BarterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarController : ControllerBase
    {
        IStarBL _StarBL;

        public StarController(IStarBL starBL)
        {
            _StarBL = starBL;
        }
        [HttpGet]
        [Route("GetAllStars")]
        public ActionResult<List<StarDTO>> GetAllStars()
        {
            List<StarDTO> stars = _StarBL.GetAllStars();
            if (stars == null)
                return NotFound();
            return Ok(stars);
        }

        [HttpGet]
        [Route("GetStarById/{id}")]
        public ActionResult<StarDTO> GetStarByIs(int id)
        {
            StarDTO star = _StarBL.GetStarById(id);
            if (star == null)
                return NotFound();
            return Ok(star);
        }

        [HttpPost]
        [Route("AddStar")]
        public bool AddStar([FromBody] StarDTO star)
        {
            var x = _StarBL.AddStar(star);
            return x;
        }

        [HttpDelete]
        [Route("DeleteStar")]
        public bool DeleteStar(int id)
        {
            return _StarBL.DeleteStar(id);
        }

        [HttpPut]
        [Route("UpdateStar/{id}")]
        public ActionResult<bool> UpdaeStar(int id, [FromBody] StarDTO star)
        {
            if (star.Id != id)

                return StatusCode(400, "id not found");
            return Ok(_StarBL.updateStar(id, star));

        }
    }
}
