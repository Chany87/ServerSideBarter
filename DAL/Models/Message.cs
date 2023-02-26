using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int? UsreIdReceived { get; set; }
        public int? UserIdGiven { get; set; }
        public DateTime? MessageDate { get; set; }
        public string MessageContent { get; set; }
        public string Image { get; set; }

        public virtual User UserIdGivenNavigation { get; set; }
        public virtual User UsreIdReceivedNavigation { get; set; }
    }
}
