using DAL.Models;
using Microsoft.EntityFrameworkCore;
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
                var Userns = bartersDBContext.CategoryUsers
                     .Where(x => x.CategotyId == id)
                     .Include(x => x.User)
                     .Select(c => new CategoryUser
                     {
                         Id = c.Id,
                         UserId = c.UserId,
                         CategotyId = c.CategotyId,
                         User = new User { Id = c.Id, FirstName = c.User.FirstName, LastName = c.User.LastName }
                     })
                     .ToList();
                return Userns;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
