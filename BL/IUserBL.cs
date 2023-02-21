using DAL.Models;
using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IUserBL
    {
        public bool AddUser(UserCreateRequest user);
        bool DeleteUser(int id);
        List<UserDTO> GetAllUsers();
        UserDTO GetUserByEmail(string email);
        UserDTO GetUserByEmailAndPassword(string email, string password);
        UserDTO GetUserById(int id);
        bool UpdateUser(int id, UserDTO user);
    }
}