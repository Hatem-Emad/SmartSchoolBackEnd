using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Interface
{
    public interface IParentRepo
    {
        public IEnumerable<ParentVM> GetAll();
        public ParentVM GetbyId(string id);

        //will be void instead of Student
        public Parent Edit(ParentVM pnt);
        //for admins or teachers
        public void Delete(string id);

        //hyshof drgat ebno hena wla fen

    }
}
