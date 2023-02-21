using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface ICategoryUserBL
    {
        List<CategoryUserDTO> GetUserByCategoryId(int id);
    }
}