using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class AdminMassage
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public string Phone { get; set; }
        public string MassageContent { get; set; }
        public string Image { get; set; }

        public virtual User User { get; set; }
    }
}
