using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MessagesDAL : IMessagesDAL
    {
        BartersDBContext bartersDBContext=new BartersDBContext();

        public List<Message> GetMessages()
        {
            try
            {
                var massege = bartersDBContext.Messages.Include(e=>e.UserIdGivenNavigation).ToList();
                return massege;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Message> GetMessageById(int id)
        {
            try
            {
                var Massege = bartersDBContext.Messages.Where(x => x.UsreIdReceived == id).ToList();
                return Massege;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddMessage(Message message)
        {
            //פונקצית הוספה
            try
            {

                bartersDBContext.Messages.Add(message);
                bartersDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

   
    }
}
