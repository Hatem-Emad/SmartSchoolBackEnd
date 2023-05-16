using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Interface;
using SmartSchool.BL.Repository;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;
using SmartSchool.DAL.Migrations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {

        public IStudentAttendanceRepo studentAttendance { get; }
        public StudentAttendanceController(IStudentAttendanceRepo StudentAttendanceRepo)
        {
            studentAttendance = StudentAttendanceRepo;

        }


        //[HttpGet]
        //[Route("getTodayAttendance")]
        //public IActionResult getTodayAttendance()
        //{
        //    try
        //    {
        //        var todayAttendance = studentAttendance.getTodayAttendance();
        //        return Ok(todayAttendance);
        //    }

        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }


        //}


        //[HttpGet]
        //[Route("getAllAttendance")]
        //public IActionResult getAllAttendance()
        //{
        //    try
        //    {
        //        var allAttendance = studentAttendance.getAllAttendance();
        //        return Ok(allAttendance);
        //    }

        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }


        //}


        [HttpPost]
        [Route("generateAttendance")]
        public IActionResult generate()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentAttendance.generateAttendance();
                   var studentsAtt= studentAttendance.getAllAttendance();
                    return Ok(studentsAtt);
                }
                return BadRequest();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }


        [HttpPut]
        [Route("addStudentAttendance")]
        public IActionResult add(IEnumerable<StudentAttendanceVM> studentAtt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentAttendance.addStudentAttendance(studentAtt);
                    return Ok(studentAtt);
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


