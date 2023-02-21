using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using System.Collections.Generic;
using System.Security.Principal;

namespace BarterServerCheck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMessageController : ControllerBase
    {
        IAdminMessageBL _iadminMessageBL;
        public AdminMessageController(IAdminMessageBL iadminMessageBL)
        {
            _iadminMessageBL = iadminMessageBL;
        }
        [HttpGet]
        [Route("GetAllMasseges")]
        public ActionResult<List<AdminMassageDTO>> GetAllMasseges() 
        {
            List<AdminMassageDTO> masseges = _iadminMessageBL.GetAllAdminMassages();
            if(masseges == null)
                return NotFound();
            return Ok(masseges);
        }

        [HttpGet]
        [Route("GatMassegeById")]
        public ActionResult<AdminMassageDTO[]> GatMassegeById(int id)
        {
            AdminMassageDTO massage = _iadminMessageBL.GetMassegeById(id);
            if(massage == null)
                return NotFound();
            return Ok(massage);
        }

        [HttpPost]
        [Route("AddAdminMessage")]
        public ActionResult<bool> AddAdminMessage([FromBody] AdminMassageDTO adminMessageDTO)
        {
            adminMessageDTO.Image = "https://localhost:44321/" + adminMessageDTO.Image;
            var x = _iadminMessageBL.AddAdminMessages(adminMessageDTO);
            return Ok(x);

        }
    }
}

