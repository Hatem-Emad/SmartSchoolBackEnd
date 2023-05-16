using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Context;
using SmartSchool.DAL.Entities;

namespace SmartSchool.BL.Repository
{
    public class TeacherAttendanceRepo : ITeacherAttendanceRepo
    {
        public SmartSchoolContext Db { get; }
        public TeacherAttendanceRepo(SmartSchoolContext _db)
        {
            Db = _db;
        }

        public IEnumerable<TeacherAttendanceVM> GetAllAttendance()
        {
            var allAttendance = Db.TeacherAttendances.Include(t => t.Teacher).Select(att => new TeacherAttendanceVM()
            {
                Id = att.Id,
                Date = att.Date,
                State = att.State,
                TeacherId = att.TeacherId,
                TeacherName = att.Teacher.FullName
            });
            return allAttendance;
        }

        public void GenerateAttendance()
        {
            var Teachers = Db.Teachers.ToList();
            for (int i = 0; i < Teachers.Count; i++)
            {
                TeacherAttendance att = new()
                {
                    Date = DateTime.Now.Date,
                    TeacherId = Teachers[i].Id,
                    State = false
                };
                Db.TeacherAttendances.Add(att);
            }

            Db.SaveChanges();
        }

        public void AddTeacherAttendance(IEnumerable<TeacherAttendanceVM> _teachersAtt)
        {
            foreach (var Teach in _teachersAtt)
            {
                var t = Db.Teachers.Find(Teach.TeacherId);

                if (t != null)
                {
                    if (Teach.State == false)
                    {
                        t.AbsenceDays += 1;
                        Db.SaveChanges();
                    }
                }
            }
        }


    }
}
