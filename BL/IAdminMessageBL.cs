using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IAdminMessageBL
    {
        bool AddAdminMessages(AdminMassageDTO adminMessageDTO);
        List<AdminMassageDTO> GetAllAdminMassages();
        AdminMassageDTO GetMassegeById(int id);
    }
}