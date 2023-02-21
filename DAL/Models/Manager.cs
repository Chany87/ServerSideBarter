using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Manager
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string SendMassegeName { get; set; }
        public int? SendMassegeId { get; set; }
        public string MassegeContent { get; set; }
    }
}
