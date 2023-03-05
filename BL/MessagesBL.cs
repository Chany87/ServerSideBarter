using AutoMapper;
using DAL.Models;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MessageBL : IMessageBL
    {
        IMessagesDAL _Messages;
        IUserDAL _userDAL;
        IMapper mapper;
        public MessageBL(IMessagesDAL Messages,IUserDAL userDAL)
        {
            _Messages = Messages;
            _userDAL = userDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }

        public List<MessageDTO> GetMessages()
        {
            List<Message> ListMessege = _Messages.GetMessages();

            List<MessageDTO> messages= mapper.Map<List<MessageDTO>>(ListMessege);
            foreach(var (m,i) in messages.Select((value, i) => (value, i)))
            {
                m.UserName = ListMessege[i].UserIdGivenNavigation.FirstName + " " + ListMessege[i].UserIdGivenNavigation.LastName;
                m.Phone = ListMessege[i].UserIdGivenNavigation.PhoneNumber;
            }
                
            return messages;
        }

        public List<MessageDTO> GetMessegeById(int id)
        {
            try
            {
                var massege = _Messages.GetMessageById(id);
                return mapper.Map<List<MessageDTO>>(massege);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddMessage(MessageDTO MessageDTO)
        {

            try
            {
                Message adminMessage = mapper.Map<Message>(MessageDTO);
                var x = _Messages.AddMessage(adminMessage);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

