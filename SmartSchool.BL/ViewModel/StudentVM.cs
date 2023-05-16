using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SmartSchool.DAL.Entities;
using SmartSchool.DAL.OurEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartSchool.BL.ViewModel
{
    public class StudentVM
    {
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
        public string? StudentPhotoUrl { set; get; }
        public string? StudentPhoto { set; get; }
        public int? MaxDayOff { get; set; }
        public int? AbsenceDays { get; set; }
        public bool? Fees { get; set; }

        [StringLength(50)]
        public string ParentID { get; set; }
        public int? ClassRoomID { get; set; }
        public string? ClassRoomName { get; set; }

    }
}
