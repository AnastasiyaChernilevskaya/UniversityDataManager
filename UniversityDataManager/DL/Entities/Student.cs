using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityDataManager.DL.Entities
{
    public class Student: BaseEntity
    {
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<StudentProject> StudentProjects { get; set; }
        public Student()
        {
            this.StudentProjects = new List<StudentProject>();
        }
    }
}