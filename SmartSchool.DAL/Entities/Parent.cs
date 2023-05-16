using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSchool.DAL.OurEnums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace SmartSchool.DAL.Entities
{
    public class Parent
    {
        [Key]
        [StringLength(50)]
    
        public string Id { get; set; }

        [Required]
        //[RegularExpression("(^[A-Za-z]{3,16})([ ]{1})([A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})")]
        public string ParentFullName { get; set; }
        [Required]
        public string ParentPhone { get; set; }
        public string IdentityParentPhotoUrl { set; get; }

        //[NotMapped]
        //public IFormFile? IdentityParentPhoto { set; get; }


        [ForeignKey("IdentityUser")]

        public string IdentityUserId { set; get; }

        public virtual IdentityUser IdentityUser { set; get; }

        //[StringLength(50)]

        //bokra isa <3
        //public string? Profession { get; set; }

        [InverseProperty("Parent")]
        public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

        [InverseProperty("Parent")]
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
