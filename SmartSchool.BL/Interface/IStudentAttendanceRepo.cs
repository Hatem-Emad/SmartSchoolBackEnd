using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IStudentAttendanceRepo
    {
        public void generateAttendance();
        public IEnumerable<StudentAttendanceVM> getAllAttendance();

        //public IEnumerable<StudentAttendanceVM> getTodayAttendance();

        public void addStudentAttendance(IEnumerable<StudentAttendanceVM> studentsAtt);

    }
}
