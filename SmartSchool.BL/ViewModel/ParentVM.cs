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
    public class ParentVM
    {
       
        [StringLength(50)]
        public string? Id { get; set; }
        //[RegularExpression("(^[A-Za-z]{3,16})([ ]{1})([A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})")]
        public string ParentFullName { get; set; }
        public string ParentPhone { get; set; }
        public string? IdentityParentPhotoUrl { set; get; }        
        public string? IdentityParentPhoto { set; get; }

    }
}
