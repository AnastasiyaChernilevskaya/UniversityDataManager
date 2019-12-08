using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using UniversityDataManager.DL.Entities.Enums;

namespace UniversityDataManager.DL.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; } = UserRoles.User;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Professor")]
        public int? ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

    }
}