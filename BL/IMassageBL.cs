using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IMassageBL
    {
        bool AddMassage(MassageDTO massageDTO);
        bool DeleteMassage(int id);
        List<MassageDTO> GetAllMassages();
        MassageDTO GetMassageById(int id);
        bool UpdateMassege(int id, MassageDTO massage);
    }
}