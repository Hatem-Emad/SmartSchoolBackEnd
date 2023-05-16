using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IStudentRepo
    {
        public IEnumerable<StudentVM> GetAll();
        public StudentVM GetbyId(string id);
        
        //will be void instead of Student
        public Student Edit(StudentVM std);
        //for admins or teachers
        public void Delete(string id);
        
    }
}
