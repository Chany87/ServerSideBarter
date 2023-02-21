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
    public class UserBL : IUserBL
    {
        IUserDAL _userDal;

        IMapper mapper;
        public UserBL(IUserDAL userDAL)
        {
            _userDal = userDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }
        public List<UserDTO> GetAllUsers()
        {
            List<User> listUsers = _userDal.GetAllUsers();

            return mapper.Map<List<UserDTO>>(listUsers);

        }
        public UserDTO GetUserById(int id)
        {

            try
            {
                var User = _userDal.GetUserById(id);
                return mapper.Map<UserDTO>(User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserDTO GetUserByEmail(string email)
        {
            //select * from Users; 
            try
            {
                var User = _userDal.GetUserByEmail(email);
                return mapper.Map<UserDTO>(User);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUser(UserCreateRequest user)
        {
            var categoryList = user.CategoryUsers;
            user.CategoryUsers = null;
            var createUser = mapper.Map<UserCreateRequest, User>(user);

            int userId = _userDal.AddUser(createUser);

            if (userId > 0)
            {
                List<CategoryUser> CategoryUserList = new List<CategoryUser>();
                categoryList.ForEach(c =>
                {
                    var cu = new CategoryUser();
                    cu.Id = 0;
                    cu.UserId = userId;
                    cu.CategotyId = c;
                    CategoryUserList.Add(cu);
                });
                //CategoryUserList לשלוח לשמירה את 
                return _userDal.saveCategoryUserList(CategoryUserList);
            }
            else
                return false;

        }
        public UserDTO GetUserByEmailAndPassword(string email, string password)
        {
            //select * from Users; 
            try
            {
                var User = _userDal.GetUserByEmailAndPassword(email, password);
                return mapper.Map<UserDTO>(User);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteUser(int id)
        {
            return _userDal.DeleteUser(id);

        }

        public bool UpdateUser(int id, UserDTO user)
        {
            User user1 = mapper.Map<UserDTO, User>(user);
            return _userDal.UpdateUsers(id, user1);
        }
    }
}



