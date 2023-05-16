using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SmartSchool.DAL.OurEnums;
using Microsoft.AspNetCore.Http;

namespace SmartSchool.DAL.Entities
{
    public class Teacher
    {


        [Key]
        public string Id { get; set; }

        [Required]
        //[RegularExpression("(^[A-Za-z]{3,16})([ ]{1})([A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})")]
        public string FullName { set; get; }


        //no need already added in Identity
        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }

        [Required]
        //don't forget to add salary annotation
        public decimal Salary { get; set; }

        [Required]
        [StringLength(11)]
        //[Phone]
        public string Phone { get; set; }

        [Required]       
        public string Address { get; set; }
        public string? PhotoUrl { set; get; }
       
        //[NotMapped]
        //public IFormFile? Photo { set; get; }

        [Required]
        public DateTime HireDate { set; get; }

        //will be adjusted
        public int? MaxDayOff { get; set; }

        public int? AbsenceDays { get; set; } = 0;

        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        [InverseProperty("Teachers")]
        public virtual Subject Subject { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { set; get; }
        public virtual IdentityUser? IdentityUser { set; get; }


        //this relation cause infinite loop x x xxxxxx
        ////should we add manytomany relation between classroom and teacher ornot?
        //[ForeignKey("TeacherId")]
        //[InverseProperty("Teachers")]
        //public virtual ICollection<ClassRoom> Classrooms { get; set; } = new List<ClassRoom>();


        //[InverseProperty("EmpNavigation")]
        //public virtual ICollection<EmployeesAttendence> EmployeesAttendences { get; set; } = new List<EmployeesAttendence>();

        //[InverseProperty("Teacher")]
        //public virtual ICollection<MaterialLibrary> MaterialLibraries { get; set; } = new List<MaterialLibrary>();

        //[InverseProperty("Teacher")]
        //public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();




    }
}
