using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AdminMassageDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public string Phone { get; set; }
        public string MassageContent { get; set; }
        public string Image { get; set; }
    
}
}
