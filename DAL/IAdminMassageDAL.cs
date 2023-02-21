using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IAdminMassageDAL
    {
        bool AddAdminMessages(AdminMassage adminMessage);
        List<AdminMassage> GetAdminMassages();
        AdminMassage GetMassageById(int id);
    }
}