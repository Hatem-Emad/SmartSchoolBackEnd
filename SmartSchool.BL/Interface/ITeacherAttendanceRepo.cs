using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSchool.BL.ViewModel;

namespace SmartSchool.BL.Interface
{
    public interface ITeacherAttendanceRepo
    {
        public void GenerateAttendance();
        public IEnumerable<TeacherAttendanceVM> GetAllAttendance();

        //public IEnumerable<TeacherAttendanceVM> getTodayAttendance();

        public void AddTeacherAttendance(IEnumerable<TeacherAttendanceVM> _teachersAtt);
    }
}
