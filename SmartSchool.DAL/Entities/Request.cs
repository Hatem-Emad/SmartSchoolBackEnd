using Microsoft.AspNetCore.Http;
using SmartSchool.DAL.OurEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Entities
{
    public class Request
    {
        [Key]
        public int id { set; get; }

        [Required]
        public string StudentFirstName { get; set; }

        [Required]
        [EmailAddress]
         public string StudentEmail { get; set; }

        [EnumDataType(typeof(Gender))]
        [Required]
        public Gender? StudentGender { get; set; }


        [Required]
        [StringLength(11)]
        //[Phone]
        public string StudentPhone { get; set; }

        [Required]
        public DateTime StudentBirthDate { get; set; }


        [Required]
       
        public string Address { get; set; }


        [Required]
        //[RegularExpression("(^[A-Za-z]{3,16})([ ]{1})([A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})")]
        //[RegularExpression("( [A-Za-z]{3,16}+\s+[A-Za-z]{3,16}\s +[A - Za - z]{ 3,16})")]
        public string ParentFullName { get; set; }


        [Required]          
        public string ParentEmail { get; set; }

        [Required]
        
        public string ParentPhone { get; set; }

        public string? StudentPhotoUrl { set; get; }
        public string? StudentBirthCertPhotoUrl { set; get; }

        //[NotMapped]
        //public IFormFile? StudentPhoto { set; get; }

        public string? IdentityParentPhotoUrl { set; get; }

        //[NotMapped]
        //public IFormFile? IdentityParentPhoto { set; get; }

        [Required]          
        public string Password { set; get; }

    }
}
