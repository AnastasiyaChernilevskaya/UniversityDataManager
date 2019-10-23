using System;
using System.Collections.Generic;
using System.Linq;
using UniversityDataManager.DL.Entities.Enums;

namespace UniversityDataManager.DL.Entities
{
    public class ProjectLog : BaseEntity
    {
        public User User { get; set; }
        public ProjectState OldProjectState { get; set; }
        public ProjectState NewProjectState { get; set; }


        public int StudentProjectId { get; set; }
        public StudentProject StudentProject { get; set; }

    }
}