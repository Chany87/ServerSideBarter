using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserDAL
    {
        int AddUser(User user);
        bool DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUserByEmail(string email);
        User GetUserByEmailAndPassword(string email, string password);
        User GetUserById(int id);
        bool saveCategoryUserList(List<CategoryUser> CategoryUserList);
        bool UpdateUsers(int id, User user);
    }
}