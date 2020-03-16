using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SMSWebAPI.Models;


namespace SMSWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        DepartmentDataAccessLayer ddal = new DepartmentDataAccessLayer();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return ddal.GetAllDepartment();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return ddal.GetDepartmentData(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Department value)
        {
            ddal.AddDepartment(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Department value)
        {
            ddal.UpdateDepartment(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ddal.DeleteDepartment(id);
        }
    }
}
