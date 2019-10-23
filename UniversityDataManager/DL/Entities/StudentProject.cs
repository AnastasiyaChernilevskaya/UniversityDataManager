using System;
using System.Collections.Generic;
using System.Linq;
using UniversityDataManager.DL.Entities.Enums;

namespace UniversityDataManager.DL.Entities
{
    public class StudentProject : BaseEntity
    {
        public double Rating { get; set; }
        public ProjectState ProjectState { get; set; }


        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int? ProfessorId { get; set; }
        public virtual Professor ProfessorVerifier { get; set; }

        public virtual List<ProjectLog> ProjectLogs { get; set; }
    }
}