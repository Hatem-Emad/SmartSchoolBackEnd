using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Context
{
    public class SmartSchoolContext : IdentityDbContext
    {
        public SmartSchoolContext(DbContextOptions<SmartSchoolContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Parent> Parents { set; get; }
        public DbSet<Request> Requests { set; get; }
        public  DbSet<ClassRoom> ClassRooms { get; set; }
        public  DbSet<Complaint> Complaints { get; set; }
        public  DbSet<Teacher> Teachers { get; set; }
        public  DbSet<GradeYear> GradeYears { get; set; }
        public  DbSet<Subject> Subjects { get; set; }
        public  DbSet<Session> Sessions { get; set; }
        public  DbSet<Schedule> Schedules { get; set; }
        public DbSet<StudentAttendance> StudAttendances { get; set; }
        public DbSet<TeacherAttendance> TeacherAttendances { get; set; }



    }

    

}
