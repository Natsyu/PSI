﻿using Microsoft.AspNetCore.Identity;
using SyllabusManager.Data.Models.ManyToMany;
using System.Collections.Generic;

namespace SyllabusManager.Data.Models.User
{
    public class SyllabusManagerUser : IdentityUser
    {
        public List<SubjectTeacher> SubjectsTeachers { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
