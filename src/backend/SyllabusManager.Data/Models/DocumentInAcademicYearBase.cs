﻿using System.ComponentModel.DataAnnotations;

namespace SyllabusManager.Data.Models
{
    public class DocumentInAcademicYearBase : ModelBase
    {
        [Required]
        public string AcademicYear { get; set; }
        [Required]
        public string Version { get; set; }
        public bool IsDeleted { get; set; }
    }
}