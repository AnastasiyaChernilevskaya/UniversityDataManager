using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityDataManager.DL.Entities
{
    public class Discipline: BaseEntity
    {
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
    }
}