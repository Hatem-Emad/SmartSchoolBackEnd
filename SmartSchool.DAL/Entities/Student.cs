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
    public class Student
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentFirstName { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender? Gender { get; set; }

        [Required]
        [StringLength(11)]
        //[Phone]
        public string StudentPhone { get; set; }

        [Required]
        public DateTime StudentBirthDate { get; set; }

        [Required]
        public string Address { get; set; }
        public string StudentPhotoUrl { set; get; }
        public string StudentBirthCertPhotoUrl { set; get; }

        //[NotMapped]
        //public IFormFile? StudentPhoto { set; get; }
        public int? MaxDayOff { get; set; }
        public int? AbsenceDays { get; set; } = 0;
        public bool? Fees { get; set; }

        [StringLength(50)]
      
        public string ParentID { get; set; }

        [ForeignKey("ParentID")]
        [InverseProperty("Students")]
        public virtual Parent Parent { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { set; get; }
        public virtual IdentityUser IdentityUser { set; get; }

        //[StringLength(50)]

        public int? ClassRoomID { get; set; }

        [ForeignKey("ClassRoomID")]
        //[InverseProperty("Students")]
        public virtual ClassRoom ClassRoom { get; set; }


        //[ForeignKey("StudentId")]
        //[InverseProperty("student")]
        public virtual ICollection<StudentAttendance> Attendances { get; set; } = new List<StudentAttendance>();

        //[InverseProperty("Student")]
        //public virtual ICollection<ExamsResult> ExamsResults { get; set; } = new List<ExamsResult>();



        //[InverseProperty("Student")]
        //public virtual ICollection<StudentsResult> StudentsResults { get; set; } = new List<StudentsResult>();

        //[ForeignKey("StudentId")]
        //[InverseProperty("Students")]
        //public virtual ICollection<StAttendance> StAttendances { get; set; } = new List<StAttendance>();
    }
}
