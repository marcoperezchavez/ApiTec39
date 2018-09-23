using System.Collections.Generic;
using ApiTec39Mio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTec39Mio.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {                                                    
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<AlumnadoGnl> Get()
        {
            var studentlisttest =  Methods.Helpers.GetAlumnosList();
            return studentlisttest;


        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<AlumnadoGnl> Get(int id)
        {
            var alumno = Methods.Helpers.GetAlumno(id);
            return alumno;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] AlumnadoGnl alumno)
        {
            var isSave = Methods.Helpers.SaveAlumno(alumno);
            if (isSave)
                return Ok();
            return BadRequest(); 
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put(AlumnadoGnl alumno)
        {
            var isUpdated = Methods.Helpers.UpdateAlumno(alumno.Id, alumno);
            if (isUpdated)
                return Ok();
            return BadRequest();
        } 

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = Methods.Helpers.DeleteId(id);
            if (isDeleted)
               return  Ok();
            return BadRequest();   
        }
    }
}
