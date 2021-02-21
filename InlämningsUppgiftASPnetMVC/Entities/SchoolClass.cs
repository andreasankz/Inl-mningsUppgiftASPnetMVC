using InlämningsUppgiftASPnetMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace InlämningsUppgiftASPnetMVC.Entities
{
    public partial class SchoolClass
    {
        public SchoolClass()
        {
            SchoolClassStudents = new HashSet<SchoolClassStudent>();
        }

        public Guid Id { get; set; }

        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Teacher")]
        public string TeacherId { get; set; }
        public DateTime Created { get; set; }

        public virtual ApplicationUser Teacher { get; set; }
        
        
        public virtual ICollection<SchoolClassStudent> SchoolClassStudents { get; set; }
    }
}
