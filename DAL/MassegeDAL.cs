using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MassegeDAL : IMassegeDAL
    {
        BartersDBContext bartersDBContext = new BartersDBContext();
        public List<Massage> GetAllMassages()
        {
            try
            {
                List<Massage> massages = bartersDBContext.Massages.ToList();
                return massages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Massage GetMassageById(int id)
        {
            try
            {
                Massage massage = bartersDBContext.Massages.SingleOrDefault(x => x.Id == id);
                return massage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Addmassage(Massage massage)
        {
            try
            {
                bartersDBContext.Massages.Add(massage);
                bartersDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateMassege(int id, Massage massage)
        {
            try
            {
                Massage massage1 = bartersDBContext.Massages.SingleOrDefault(x => x.Id == id);
                bartersDBContext.Entry(massage1).CurrentValues.SetValues(massage);
                bartersDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMassege(int id)
        {
            try
            {
                Massage massage = bartersDBContext.Massages.SingleOrDefault(x => x.Id == id);
                bartersDBContext.Massages.Remove(massage);
                bartersDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}




