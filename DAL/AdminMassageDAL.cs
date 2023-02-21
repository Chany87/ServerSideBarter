using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminMassageDAL : IAdminMassageDAL
    {
        BartersDBContext bartersDBContext = new BartersDBContext();

        public List<AdminMassage> GetAdminMassages()
        {
            try
            {
                var massege = bartersDBContext.AdminMassages.ToList();
                return massege;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public AdminMassage GetMassageById(int id)
        {
            try
            {
                var Massege = bartersDBContext.AdminMassages.SingleOrDefault(x => x.Id == id);
                return Massege;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddAdminMessages(AdminMassage adminMessage)
        {
            //פונקצית הוספה
            try
            {

                bartersDBContext.AdminMassages.Add(adminMessage);
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
