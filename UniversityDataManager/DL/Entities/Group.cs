using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityDataManager.DL.Entities
{
    public class Group:BaseEntity
    {
        public string GroupName { get; set; }
        public virtual List<Student> Students { get; set; }
        public Student Praepostor { get; set; }

        public List<Project> Projects { get; set; }
    }
}