using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? UserIdGiven { get; set; }
        public int? UsreIdReceived { get; set; }
        public string Phone { get; set; }
        public string MessageContent { get; set; }
        public string Image { get; set; }
        public DateTime? MessageDate { get; set; }

    }
}
