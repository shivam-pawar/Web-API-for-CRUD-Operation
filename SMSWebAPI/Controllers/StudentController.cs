using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SMSWebAPI.Models;

namespace SMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        StudentDataAccessLayer sdal = new StudentDataAccessLayer();
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return sdal.GetAllStudent();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return sdal.GetStudentData(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Student value)
        {
            sdal.AddStudent(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Student value)
        {
            sdal.UpdateStudent(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sdal.DeleteStudent(id);
        }
    }
}
