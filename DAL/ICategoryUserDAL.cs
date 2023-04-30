using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface ICategoryUserDAL
    {
        List<CategoryUser> GetUserByCategoryId(int id);

    }
}