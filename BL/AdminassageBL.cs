using AutoMapper;
using DAL.Models;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AdminMessageBL : IAdminMessageBL
    {
        IAdminMassageDAL _dminMessages;
        IMapper mapper;
        public AdminMessageBL(IAdminMassageDAL adminMessages)
        {
            _dminMessages = adminMessages;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }

        public List<AdminMassageDTO> GetAllAdminMassages()
        {
            List<AdminMassage> ListMassege = _dminMessages.GetAdminMassages();

            return mapper.Map<List<AdminMassageDTO>>(ListMassege);
        }

        public AdminMassageDTO GetMassegeById(int id)
        {
            try
            {
                var massege = _dminMessages.GetMassageById(id);
                return mapper.Map<AdminMassageDTO>(massege);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddAdminMessages(AdminMassageDTO adminMessageDTO)
        {

            try
            {
                AdminMassage adminMessage = mapper.Map<AdminMassage>(adminMessageDTO);
                var x = _dminMessages.AddAdminMessages(adminMessage);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

