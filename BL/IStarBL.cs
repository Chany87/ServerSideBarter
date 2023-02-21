using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IStarBL
    {
        bool AddStar(StarDTO star);
        bool DeleteStar(int id);
        List<StarDTO> GetAllStars();
        StarDTO GetStarById(int id);
        bool updateStar(int id, StarDTO star);
    }
}