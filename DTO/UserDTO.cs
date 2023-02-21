using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public int AllowingAccess { get; set; }
        public string Password { get; set; }
        public int? Stars { get; set; }

        public List<CategoryUserDTO> CategoryUsers { get; set; }


    }
}
