using BarterServer.Controllers;
using BL;
using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BarterServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MassegeController : ControllerBase
    {
        IMassageBL _massageBL;
        public MassegeController(IMassageBL massageBL)
        {
            _massageBL = massageBL;
        }
        [HttpGet]
        [Route("GetAllMassages")]
        public ActionResult<List<MassageDTO>> GetAllMassages()
        {
            List<MassageDTO> massages = _massageBL.GetAllMassages();
            if (massages == null)
                return NotFound();
            return Ok(massages);
        }
        [HttpGet]
        [Route("GetMassageById/{id}")]
        public ActionResult<MassageDTO> GetMassageById(int id)
        {
            MassageDTO massage = _massageBL.GetMassageById(id);
            if (massage == null)
                return NotFound();
            return Ok(massage);
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult<bool> AddMassage([FromBody] MassageDTO massageDTO)
        {

            return Ok(_massageBL.AddMassage(massageDTO));

        }
        [HttpDelete]
        [Route("DeleteMassege")]
        public bool DeleteMassege(int id)
        {
            return _massageBL.DeleteMassage(id);
        }

        [HttpPut]
        [Route("UpdateMaassege")]
        public bool UpdateMassege(int id, [FromBody] MassageDTO massageDTO)
        {
            return _massageBL.UpdateMassege(id, massageDTO);
        }
    }
}

