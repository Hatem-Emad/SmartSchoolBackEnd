using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAttendanceController : ControllerBase
    {
        public ITeacherAttendanceRepo Repo { get; }
        public TeacherAttendanceController(ITeacherAttendanceRepo _repo)
        {
            Repo = _repo;
        }
        
        [HttpPost]
        [Route("generateAttendance")]
        public IActionResult Generate()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.GenerateAttendance();
                    var TeachersAtt = Repo.GetAllAttendance();
                    return Ok(TeachersAtt);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("addTeacherAttendance")]
        public IActionResult Add(IEnumerable<TeacherAttendanceVM> teacherAtt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddTeacherAttendance(teacherAtt);
                    return Ok(teacherAtt);
                }
                return BadRequest();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
