using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityDataManager.DL.Entities
{
    public class Professor : BaseEntity
    {
        public virtual User User { get; set; }
        public List<StudentProject> VerifiedStudentProjects { get; set; }
        public virtual List<Discipline> Disciplines { get; set; }
        public List<Project> CreatedProjects { get; set; }
    }
}