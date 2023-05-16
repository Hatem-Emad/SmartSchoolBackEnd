using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.BL.Helpers;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Context;
using SmartSchool.DAL.Entities;
using SmartSchool.DAL.OurEnums;

namespace SmartSchool.BL.Repository
{
    public class StudentRepo : IStudentRepo
    {
        public SmartSchoolContext Db { get; }
        public StudentRepo(SmartSchoolContext _db)
        {
            Db = _db;
        }

        public IEnumerable<StudentVM> GetAll()
        {
            var allStuds = Db.Students.Include(s => s.ClassRoom).Select(s => new StudentVM()
            {
                Id = s.Id,
                AbsenceDays = s.AbsenceDays,
                Address = s.Address,
                ClassRoomID = s.ClassRoomID,
                ClassRoomName = s.ClassRoom.Name,
                Fees = s.Fees,
                Gender = s.Gender,
                MaxDayOff = s.MaxDayOff,
                ParentID = s.ParentID,
                StudentBirthDate = s.StudentBirthDate,
                StudentFirstName = s.StudentFirstName,
                StudentPhone = s.StudentPhone,
                StudentPhotoUrl = s.StudentPhotoUrl
            });

            return allStuds;
        }
        public StudentVM GetbyId(string id)
        {
            var myStud = Db.Students.Where(s => s.Id == id).Include(s => s.ClassRoom).Select(s => new StudentVM()
            {
                Id = s.Id,
                AbsenceDays = s.AbsenceDays,
                Address = s.Address,
                ClassRoomID = s.ClassRoomID,
                ClassRoomName = s.ClassRoom.Name,
                Fees = s.Fees,
                Gender = s.Gender,
                MaxDayOff = s.MaxDayOff,
                ParentID = s.ParentID,
                StudentBirthDate = s.StudentBirthDate,
                StudentFirstName = s.StudentFirstName,
                StudentPhone = s.StudentPhone,
                StudentPhotoUrl = s.StudentPhotoUrl
            }) .FirstOrDefault();

            return myStud;
        }
        public Student Edit(StudentVM std)
        {
            Student student = Db.Students.Find(std.Id);
            student.Id = std.Id;
            student.AbsenceDays = std.AbsenceDays;
            student.Address = std.Address;
            student.ClassRoomID = std.ClassRoomID;
            student.Fees = std.Fees;
            student.Gender = std.Gender;
            student.MaxDayOff = std.MaxDayOff;
            student.ParentID = std.ParentID;
            student.StudentBirthDate = std.StudentBirthDate;
            student.StudentFirstName = std.StudentFirstName;
            student.StudentPhone = std.StudentPhone;
            if(std.StudentPhoto != null)
            {
                student.StudentPhotoUrl = UploadFile.Photo(std.StudentPhoto, "StudentImages");
            }
            else
            {
                student.StudentPhotoUrl = std.StudentPhotoUrl;
            }
            Db.SaveChanges();
            return student;
        }
        public void Delete(string id)
        {
            Db.Students.Remove(Db.Students.Find(id));
            Db.SaveChanges();
        }
    }
}
