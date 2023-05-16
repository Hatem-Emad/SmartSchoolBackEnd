using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using SmartSchool.DAL.OurEnums;
using System.Text.Json.Serialization;

namespace SmartSchool.BL.ViewModel
{
    public class TeacherVM
    {
        public string Id { get; set; }

        [Required]
        //[RegularExpression("(^[A-Za-z]{3,16})([ ]{1})([A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})")]
        public string FullName { set; get; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { set; get; }

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

        [JsonIgnore]
        public string? PhotoUrl { get; set; }
        public string? Photo { set; get; }
        
        //[NotMapped]
        //[JsonIgnore]
        //public IFormFile? Photo { set; get; }


        [Required]
        public DateTime HireDate { set; get; }

        public int? MaxDayOff { get; set; }

        public int? AbsenceDays { get; set; }


        public int SubjectId { get; set; }

        //we added this for better presentation for teacher when getall or getbyid
        public string? SubjectName { get; set; }

        //[ForeignKey("SubjectId")]
        //[InverseProperty("Teachers")]
        //public virtual Subject Subject { get; set; }

        [ForeignKey("IdentityUser")]
        //put ? or not ?

        public string? IdentityUserId { set; get; }

        //public virtual IdentityUser IdentityUser { set; get; }
    }
}
