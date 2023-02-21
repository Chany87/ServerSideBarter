using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Models;
using DTO;

namespace BL
{
    public class MassageBL : IMassageBL
    {
        IMassegeDAL _massageDal;

        IMapper mapper;
        public MassageBL(IMassegeDAL massageDAL)
        {
            _massageDal = massageDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }
        public List<MassageDTO> GetAllMassages()
        {
            List<Massage> listMassages = _massageDal.GetAllMassages();

            return mapper.Map<List<MassageDTO>>(listMassages);
        }
        public MassageDTO GetMassageById(int id)
        {

            try
            {
                var Massage = _massageDal.GetMassageById(id);
                return mapper.Map<MassageDTO>(Massage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddMassage(MassageDTO massageDTO)
        {
            try
            {
                Massage massage = mapper.Map<Massage>(massageDTO);
                return _massageDal.Addmassage(massage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteMassage(int id)
        {
            try
            {
                return _massageDal.DeleteMassege(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateMassege(int id, MassageDTO massage)
        {
            try
            {
                Massage massage1 = mapper.Map<Massage>(massage);
                return _massageDal.UpdateMassege(id, massage1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
