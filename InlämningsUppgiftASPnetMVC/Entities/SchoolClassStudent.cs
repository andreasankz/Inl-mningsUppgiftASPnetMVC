using InlämningsUppgiftASPnetMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace InlämningsUppgiftASPnetMVC.Entities
{
    public partial class SchoolClassStudent 
    {
       
        public string StudentId { get; set; }

        [Display(Name = "Class Name")]
        public Guid SchoolClassId { get; set; }


        [Display(Name = "Class Name")]
        public virtual SchoolClass SchoolClass { get; set; }
       
       
    }
}
