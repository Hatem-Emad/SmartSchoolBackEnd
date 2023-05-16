using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.BL.Helpers;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Context;
using SmartSchool.DAL.Entities;

namespace SmartSchool.BL.Repository
{
    public class ParentRepo : IParentRepo
    {
        public SmartSchoolContext Db { get; }

        public ParentRepo(SmartSchoolContext _db)
        {
            Db = _db;
        }
        public IEnumerable<ParentVM> GetAll()
        {
            var allPnts = Db.Parents.Select(p => new ParentVM()
            {
                Id = p.Id,
                ParentFullName = p.ParentFullName,
                ParentPhone = p.ParentPhone,
                IdentityParentPhotoUrl = p.IdentityParentPhotoUrl
            });
             return allPnts;
            
        }

        public ParentVM GetbyId(string id)
        {
            var myPnt = Db.Parents.Where(p => p.Id == id).Select(p => new ParentVM()
            {
                Id = p.Id,
                ParentFullName = p.ParentFullName,
                ParentPhone = p.ParentPhone,
                IdentityParentPhotoUrl = p.IdentityParentPhotoUrl
            }) .FirstOrDefault();

            return myPnt;
        }
        public Parent Edit(ParentVM pnt)
        {
            Parent parent = Db.Parents.Find(pnt.Id);
            parent.Id = pnt.Id;
            parent.ParentFullName = pnt.ParentFullName;
            parent.ParentPhone = pnt.ParentPhone;
            
            if(pnt.IdentityParentPhoto != null)
            {
                parent.IdentityParentPhotoUrl = UploadFile.Photo(pnt.IdentityParentPhoto, "IdentityParentImages");
            }
            else
            {
                parent.IdentityParentPhotoUrl = pnt.IdentityParentPhotoUrl;
            }
            Db.SaveChanges();
            return parent;

        }
        public void Delete(string id)
        {
            Db.Parents.Remove(Db.Parents.Find(id));
            Db.SaveChanges();
        }
    }
}
