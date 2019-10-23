using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityDataManager.DL.Entities
{
    public class Project : BaseEntity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
        public double MaxRating { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }

        public virtual Professor Creator { get; set; }

        public virtual List<Group> Groups { get; set; }
        public virtual List<Professor> Professors { get; set; }

        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }
    }
}