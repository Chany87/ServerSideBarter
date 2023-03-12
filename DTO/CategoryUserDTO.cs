
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryUserDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CategotyId { get; set; }
        public virtual UserDTO User { get; set; }
    }
}
