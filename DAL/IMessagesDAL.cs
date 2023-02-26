using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IMessagesDAL
    {
        bool AddMessage(Message message);
        List<Message> GetMessages();
        Message GetMessageById(int id);
    }
}