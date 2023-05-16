using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Context;
using SmartSchool.DAL.Entities;
using SmartSchool.DAL.OurEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Repository
{
    public class TeacherRepo : ITeacherRepo
    {
        public TeacherRepo(SmartSchoolContext db)
        {
            Db = db;
            
        }
        public SmartSchoolContext Db { get; }
        public void SaveInDb(TeacherVM obj, string TeacherId)
        {
            Teacher T = new Teacher()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = obj.FullName,
                Gender = obj.Gender,
                Phone = obj.Phone,
                Salary = obj.Salary,
                SubjectId = obj.SubjectId,
                Address = obj.Address,
                PhotoUrl= obj.PhotoUrl,
                HireDate = obj.HireDate,

                //new
                IdentityUserId = TeacherId,
            };

            Db.Teachers.Add(T);
            Db.SaveChanges();
        }
        public IEnumerable<TeacherVM> GetAll()
        {
            var allTeachers = Db.Teachers.Include("Subject").Select(obj => new TeacherVM()
            {
                Id = obj.Id,
                FullName = obj.FullName,
                Gender = obj.Gender,
                Phone = obj.Phone,
                Salary = obj.Salary,
                SubjectId = obj.SubjectId,
                Address = obj.Address,
                PhotoUrl = obj.PhotoUrl,
                HireDate = obj.HireDate,
                SubjectName = obj.Subject.Name,
            });

            return allTeachers;
        }
        public TeacherVM GetById(string id)
        {
            var myTeacher = Db.Teachers.Include("Subject").Where(r => r.Id == id).Select(obj => new TeacherVM()
            {
                Id = obj.Id,
                FullName = obj.FullName,
                Gender = obj.Gender,
                Phone = obj.Phone,
                Salary = obj.Salary,
                SubjectId = obj.SubjectId,
                Address = obj.Address,
                PhotoUrl = obj.PhotoUrl,
                HireDate = obj.HireDate,
                SubjectName = obj.Subject.Name,

            }).FirstOrDefault();

            return myTeacher;
        }

        public void Delete(string id)
        {
            var myTeacher = Db.Teachers.Find(id);
            Db.Teachers.Remove(myTeacher);
            Db.SaveChanges();
        }

        public Teacher Edit(string id, TeacherVMEdit obj)
        {
            //Teacher t =  Db.Teachers.Find(id);

            // t.Id = obj.Id??t.Id;
            // t.FullName = obj.FullName ?? t.FullName;
            // t.Gender = obj.Gender ?? t.Gender;
            // t.Phone = obj.Phone ?? t.Phone;
            // t.Salary = obj.Salary == 0 ?  t.Salary : obj.Salary;
            // t.SubjectId = obj.SubjectId == 0 ? t.SubjectId : obj.SubjectId;
            // t.Address = obj.Address ?? t.Address;
            // t.PhotoUrl = obj.PhotoUrl ?? t.PhotoUrl;
            // //t.HireDate =obj.HireDate==null? t.HireDate : obj.HireDate ;
            // t.HireDate = obj.HireDate == default ? t.HireDate : obj.HireDate;
            // //obj.Email = "aahmedaayman@gmail.com";
            // //obj.Password = "#AhemdAYman95";
            // //obj.IdentityUserId = "3cd4d39c-17aa-4c78-b6a5-24ed873afe3d";

            Teacher t = Db.Teachers.Find(id);

            t.Id = obj.Id ?? t.Id;
            t.FullName = obj.FullName ?? t.FullName;
            t.Gender = obj.Gender ?? t.Gender;
            t.Phone = obj.Phone ?? t.Phone;
            t.Salary = obj.Salary ??  t.Salary;
            t.SubjectId = obj.SubjectId == 0 ? t.SubjectId : obj.SubjectId;
            t.Address = obj.Address ?? t.Address;
            t.PhotoUrl = obj.PhotoUrl ?? t.PhotoUrl;
            //t.HireDate =obj.HireDate==null? t.HireDate : obj.HireDate ;
            t.HireDate = obj.HireDate ?? t.HireDate;
            //obj.Email = "aahmedaayman@gmail.com";
            //obj.Password = "#AhemdAYman95";
            //obj.IdentityUserId = "3cd4d39c-17aa-4c78-b6a5-24ed873afe3d";
            //t.IdentityUserId = "e1d40151-ef6b-4a7d-82eb-0ce6c768a519";




            Db.SaveChanges();
            return t;


        }

    }
}
