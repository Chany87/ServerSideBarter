﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
