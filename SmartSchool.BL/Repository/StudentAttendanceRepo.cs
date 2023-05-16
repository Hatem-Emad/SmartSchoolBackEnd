using Microsoft.EntityFrameworkCore;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Context;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Repository
{
    public class StudentAttendanceRepo : IStudentAttendanceRepo
    {
        public SmartSchoolContext Db { get; }
        public StudentAttendanceRepo(SmartSchoolContext db)
        {
            Db = db;

        }

        //no need now

        //public IEnumerable<StudentAttendanceVM> getTodayAttendance()
        //{
        //    var todayAttendance = Db.StudAttendances.Include(s => s.student).Where(att=>att.date.ToString("dddd") ==DateTime.Now.ToString("dddd")).Select(att => new StudentAttendanceVM()
        //    {

        //        id = att.id,
        //        date = att.date,
        //        state = att.state,
        //        studentId = att.studentId,
        //        studentName = att.student.StudentFirstName


        //    });


        //    return todayAttendance;
        //}
        public IEnumerable<StudentAttendanceVM> getAllAttendance()
        {
            var allAttendance = Db.StudAttendances.Include(s => s.student).Select(att => new StudentAttendanceVM()
            {

                id = att.id,
                date = att.date,
                state = att.state,
                studentId = att.studentId,
                studentName = att.student.StudentFirstName


            });


            return allAttendance;
        }


        public void generateAttendance()
        {
            var students = Db.Students.ToList();
            for (int i = 0; i < students.Count; i++)
            {
                StudentAttendance att = new StudentAttendance()
                {
                    date = DateTime.Now.Date,
                    studentId = students[i].Id,
                    state = false
                };
                Db.StudAttendances.Add(att);
            }

            Db.SaveChanges();
        }

        // delete attendance record after take student attendance

        public void addStudentAttendance(IEnumerable<StudentAttendanceVM> studentsAtt)
        {
            foreach (var stud in studentsAtt)
            {
                var s = Db.Students.Find(stud.studentId);

                if (s != null)
                {
                    if (stud.state == false)
                    {
                        s.AbsenceDays += 1;
                        Db.SaveChanges();
                    }
                }
            }
        }
    }
}
