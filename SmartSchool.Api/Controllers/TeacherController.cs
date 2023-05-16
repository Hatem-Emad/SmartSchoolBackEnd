using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Helpers;
using SmartSchool.BL.Interface;
using SmartSchool.BL.Models;
using SmartSchool.BL.Repository;
using SmartSchool.BL.Services;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Entities;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public ITeacherRepo TeacherRepo { get; }
        private readonly IAuthService authService;
        private readonly UserManager<IdentityUser> UserManager;
        public TeacherController(ITeacherRepo teacherrepo, IAuthService authService, UserManager<IdentityUser> userManager)
        {
            this.TeacherRepo = teacherrepo;
            this.authService = authService;
            this.UserManager = userManager;
        }

        [HttpPost]
        [Route("Save")]
        //where to send the list of subject names ?? here or in front ??
        public async Task<IActionResult> RegisterAsync(TeacherVM obj)
        {
            if (obj == null)
            {
                return BadRequest("Object Is Null");
            }
            try
            {
                if(ModelState.IsValid) 
                {
                    if (obj.Photo  != null)
                        obj.PhotoUrl = UploadFile.Photo(obj.Photo, "TeacherImages");
                    
                    RegisterModel myTeacher = new RegisterModel()
                    {
                        Email = obj.Email,
                        Username = obj.FullName,
                        Password = obj.Password,
                        //Password = "#SmartSchool2023",
                        myRole = "Teacher"
                    };

                    var Teacher = await authService.RegisterAsync(myTeacher);
                    var TeacherIdentityId = UserManager.FindByEmailAsync(myTeacher.Email).Result.Id;
                    TeacherRepo.SaveInDb(obj, TeacherIdentityId);
                    return Ok(Teacher);

                }
                else
                {
                    return BadRequest();
                }
                #region commented
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest();
                //}
                //RegisterModel myTeacher = new RegisterModel()
                //{
                //    Email = obj.Email,
                //    Username = obj.FullName,
                //    Password = obj.Password,
                //    //Password = "#SmartSchool2023",

                //    myRole = "Teacher"
                //};


                //var Teacher = await authService.RegisterAsync(myTeacher);


                //l gded
                //var TeacherIdentityId = UserManager.FindByEmailAsync(myTeacher.Email).Result.Id;



                //we will send id in action paremter    
                //l gded
                //TeacherRepo.SaveInDb(obj, TeacherIdentityId);

                //return Ok({ token = result.Token, expireOn = result.ExpireOn});

                //return Ok(result);
                //return Ok(Teacher); 
                #endregion
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpGet]
            [Route("GetAll")]
            public IActionResult Get()

            {
                try
                {
                    var allTeachers = TeacherRepo.GetAll();
                    return Ok(allTeachers);
                }

                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }

            }

            [HttpGet]
            [Route("GetById/{id}")]
            public IActionResult GetById(string id)
            {
                try
                {
                    var myTeacher = TeacherRepo.GetById(id);
                    if (myTeacher == null)
                    {
                        return NotFound();
                    }
                    return Ok(myTeacher);
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(string id)
        {
            try
            {
               TeacherRepo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        //in front end they must make sure that all inputs all filled with data :))
        //we used new viewmodel for teach for edit.
        [HttpPut]
        [Route("Edit")]
        public ActionResult Edit (string id, TeacherVMEdit obj)
        {

            Teacher t = TeacherRepo.Edit(id,obj);
            return Ok(t);
        }



    }
 }

