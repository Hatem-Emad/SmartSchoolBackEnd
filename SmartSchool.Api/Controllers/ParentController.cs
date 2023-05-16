using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.BL.Interface;
using SmartSchool.BL.ViewModel;
using SmartSchool.DAL.Context;
using SmartSchool.DAL.Entities;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        public IParentRepo Repo { get; }
        public ParentController(IParentRepo _repo)
        {
            Repo = _repo;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var allParents = Repo.GetAll();
                return Ok(allParents);
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
                var myPnt = Repo.GetbyId(id);
                if(myPnt == null) 
                {
                    return NotFound();
                }
                return Ok(myPnt);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(ParentVM pnt)
        {
            Parent P = Repo.Edit(pnt);
            return Ok(P);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                Repo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

