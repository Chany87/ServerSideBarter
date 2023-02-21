using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryUserBL : ICategoryUserBL
    {
        ICategoryUserDAL _categoryUserDAL;
        IMapper _mapper;
        public CategoryUserBL(ICategoryUserDAL categoryUserDAL)
        {
            _categoryUserDAL = categoryUserDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = config.CreateMapper();
        }
        public List<CategoryUserDTO> GetUserByCategoryId(int id)
        {
            List<CategoryUser> listCategoryUsers = _categoryUserDAL.GetUserByCategoryId(id);

            return _mapper.Map<List<CategoryUserDTO>>(listCategoryUsers);
        }
    }
}
