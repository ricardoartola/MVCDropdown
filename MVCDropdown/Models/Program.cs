﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropdown.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}