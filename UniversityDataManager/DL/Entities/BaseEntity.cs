using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityDataManager.DL.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }

    }
}