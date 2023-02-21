using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryUserDAL : ICategoryUserDAL
    {
        BartersDBContext bartersDBContext = new BartersDBContext();

        public List<CategoryUser> GetUserByCategoryId(int id)
        {
            try
            {
                var Userns = bartersDBContext.CategoryUsers.Where(x => x.CategotyId == id).ToList();
                return Userns;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
