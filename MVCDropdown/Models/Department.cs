using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDropdown.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public ICollection<Program> Programs { get; set; }
    }
}