﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class User
    {
        public User()
        {
            CategoryUsers = new HashSet<CategoryUser>();
            CustomerInquiries = new HashSet<CustomerInquiry>();
            MessageUserIdGivenNavigations = new HashSet<Message>();
            MessageUsreIdReceivedNavigations = new HashSet<Message>();
            OpinionDrages = new HashSet<Opinion>();
            OpinionGradeds = new HashSet<Opinion>();
            Publications = new HashSet<Publication>();
            StarUserIdGivenNavigations = new HashSet<Star>();
            StarUserIdReceivedNavigations = new HashSet<Star>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? CityId { get; set; }
        public int AllowingAccess { get; set; }
        public string Password { get; set; }
        public int? Stars { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<CategoryUser> CategoryUsers { get; set; }
        public virtual ICollection<CustomerInquiry> CustomerInquiries { get; set; }
        public virtual ICollection<Message> MessageUserIdGivenNavigations { get; set; }
        public virtual ICollection<Message> MessageUsreIdReceivedNavigations { get; set; }
        public virtual ICollection<Opinion> OpinionDrages { get; set; }
        public virtual ICollection<Opinion> OpinionGradeds { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
        public virtual ICollection<Star> StarUserIdGivenNavigations { get; set; }
        public virtual ICollection<Star> StarUserIdReceivedNavigations { get; set; }
    }
}
