using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Helpers;
using SmartSchool.BL.Interface;
using SmartSchool.BL.Models;
using SmartSchool.BL.Services;
using SmartSchool.BL.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly UserManager<IdentityUser> UserManager;

        public IRequestRepo RequestRepo { get; }
        public RequestController(IRequestRepo requestRepo, IAuthService authService,UserManager<IdentityUser> userManager)
        {
            RequestRepo = requestRepo;
            this.authService = authService;
            this.UserManager = userManager;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateRequest(RequestVM obj)
        {
            if (obj == null)
            {
                return BadRequest("Object Is Null");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    //Random rnd = new Random();
                    if (obj.StudentPhoto != null)
                    {
                        //Byte[] bytes = Convert.FromBase64String(obj.StudentPhoto);
                        ////check that photo must be jpg
                        //string filePath1 = ("UserImages/" + Path.GetFileName(obj.StudentFirstName) + rnd.Next() + ".jpg");
                        ////System.IO.File.WriteAllBytes(filePath1, bytes);
                        //System.IO.File.WriteAllBytes("wwwroot/" + filePath1, bytes);
                        //obj.StudentPhotoUrl = filePath1;
                        
                        obj.StudentPhotoUrl = UploadFile.Photo(obj.StudentPhoto, "StudentImages");
                    }
                    if (obj.IdentityParentPhoto != null)
                    {
                        //Byte[] bytes = Convert.FromBase64String(obj.IdentityParentPhoto);
                        //string filePath2 = ("UserImages/" + Path.GetFileName(obj.ParentFullName) + rnd.Next() + ".jpg");
                        ////System.IO.File.WriteAllBytes(filePath2, bytes);
                        //System.IO.File.WriteAllBytes("wwwroot/" + filePath2, bytes);
                        //obj.IdentityParentPhotoUrl = filePath2;
                       
                        obj.IdentityParentPhotoUrl = UploadFile.Photo(obj.IdentityParentPhoto, "IdentityParentImages");
                    }
                    if(obj.StudentBirthCertPhoto != null)
                    {
                        obj.StudentBirthCertPhotoUrl = UploadFile.Photo(obj.StudentBirthCertPhoto, "StudentImages");
                    }
                    RequestRepo.Create(obj);
                    //what to write inside created to redirect to getall page??
                    //try created
                    return Ok(obj);
                }
                return BadRequest();
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
                var allRequests = RequestRepo.GetAll();
                return Ok(allRequests);
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var myRequest = RequestRepo.GetById(id);
                if(myRequest == null)
                {
                    return NotFound();
                }
                return Ok(myRequest);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
            
        }

        //working but longer code
        //[HttpPost]
        //[Route("GetByIdThenSave/{id}")]
        //public IActionResult SaveInDb(int id)
        //{
        //    RequestRepo.SaveInDb(id);
        //    return Ok();
        //}


        //[HttpGet]
        //[Route("Save/{id}")]
        //public async Task<IActionResult> RegisterAsync(int id)
        //{
        //    var myRequest = RequestRepo.GetById(id);
        //    return Ok(myRequest);
        //}


        //[HttpPost]
        //[Route("Save")]
        ////l function deh shaghala we zay l fol
        ////fadel nemsek l request 3n tree2 l ID :)
        //public async Task<IActionResult> RegisterAsync(int id,RequestVM obj)
        //{
        //    //if (!ModelState.IsValid)
        //    //    return BadRequest(ModelState);
        //    if(id == obj.id)
        //    {
        //        RegisterModel myParent = new RegisterModel()
        //        {
        //            Email = obj.ParentEmail,
        //            Username = obj.ParentEmail,
        //            Password = obj.Password,
        //            //Password = "#SmartSchool2023",

        //            myRole = "Parent"
        //        };

        //        RegisterModel myStudent = new RegisterModel()
        //        {
        //            Email = obj.StudentEmail,
        //            Username = obj.StudentEmail,
        //            Password = obj.Password,

        //            //Password = "#SmartSchool2023",
        //            myRole = "Student"
        //        };
        //        var Parent = await authService.RegisterAsync(myParent);
        //        var Student = await authService.RegisterAsync(myStudent);




        //        //we will send id in action paremter
        //        RequestRepo.SaveInDb(obj.id);

        //        //return Ok({ token = result.Token, expireOn = result.ExpireOn});

        //        //return Ok(result);
        //        return Ok(new { Parent, Student });
        //    }

        //    return BadRequest();

        //}

        [HttpPost]
        [Route("Save/{id}")]
        public async Task<IActionResult> RegisterAsync(int id)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);
            var obj = RequestRepo.GetById(id);
                RegisterModel myParent = new RegisterModel()
                {
                    Email = obj.ParentEmail,
                    Username = obj.ParentEmail,
                    Password = obj.Password,
                    //Password = "#SmartSchool2023",

                    myRole = "Parent"
                };

                RegisterModel myStudent = new RegisterModel()
                {
                    Email = obj.StudentEmail,
                    Username = obj.StudentEmail,
                    Password = obj.Password,

                    //Password = "#SmartSchool2023",
                    myRole = "Student"
                };
                var Parent = await authService.RegisterAsync(myParent);
                var Student = await authService.RegisterAsync(myStudent);

            //l gded
                var ParentIdentityId = UserManager.FindByEmailAsync(myParent.Email).Result.Id;
                var StudentIdentityId= UserManager.FindByEmailAsync(myStudent.Email).Result.Id;



            //we will send id in action paremter    
            //l gded
            RequestRepo.SaveInDb(obj.id, ParentIdentityId, StudentIdentityId);
            RequestRepo.Delete(id);
            string message = "success";
                //return Ok({ token = result.Token, expireOn = result.ExpireOn});

            //return Ok(result);
                return Ok(new {message, Parent, Student });      

        }

        [HttpDelete]
        
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
               RequestRepo.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
