using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IMessageBL
    {
        bool AddMessage(MessageDTO MessageDTO);
        List<MessageDTO> GetMessages();
        List<MessageDTO> GetMessegeById(int id);
    }
}