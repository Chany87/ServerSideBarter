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
    public class MessagesController : ControllerBase
    {
        IMessageBL _iMessageBL;
        public MessagesController(IMessageBL iMessageBL)
        {
            _iMessageBL = iMessageBL;
        }
        [HttpGet]
        [Route("GetAllMessages")]
        public ActionResult<List<MessageDTO>> GetAllMessages() 
        {
            List<MessageDTO> masseges = _iMessageBL.GetMessages();
            if(masseges == null)
                return NotFound();
            return Ok(masseges);
        }

        [HttpGet]
        [Route("GatMessegeById")]
        public ActionResult<MessageDTO[]> GatMessegeById(int id)
        {
            MessageDTO massage = _iMessageBL.GetMessegeById(id);
            if(massage == null)
                return NotFound();
            return Ok(massage);
        }

        [HttpPost]
        [Route("AddMessage")]
        public ActionResult<bool> AddAMessage([FromBody] MessageDTO MessageDTO)
        {
            MessageDTO.Image = "https://localhost:44321/" + MessageDTO.Image;
            var x = _iMessageBL.AddMessage(MessageDTO);
            return Ok(x);

        }
    }
}

