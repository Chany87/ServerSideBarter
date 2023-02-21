using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IMassegeDAL
    {
        bool Addmassage(Massage massage);
        bool DeleteMassege(int id);
        List<Massage> GetAllMassages();
        Massage GetMassageById(int id);
        bool UpdateMassege(int id, Massage massage);
    }
}