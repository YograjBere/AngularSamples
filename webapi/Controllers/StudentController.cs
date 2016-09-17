using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using webapi.Infrastructure.Logger;
using webapi.Infrastructure.Repository;
using webapi.Models;

namespace webapi.Controllers
{
    [RoutePrefix("Students")]
    public class StudentApiController : ApiController
    {
        private IStudentRepository _studentRepository;
        private ILogger _logger;
        private string _operationName = string.Empty;

        public StudentApiController(IStudentRepository repository, ILogger logger)
        {
            _studentRepository = repository;
            _logger = logger;
        }

        [HttpPost]
        public IHttpActionResult CreateStudent(Student student)
        {
            _operationName = "Create Student";

            Func<IHttpActionResult> operation = () =>
            {
                var id = _studentRepository.CreateStudent(student);
                return Ok(id);
            };

            return PerformOperation(operation);
        }

        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            _operationName = "Delete Student";

            Func<IHttpActionResult> operation = () =>
            {
                _studentRepository.DeleteStudent(id);
                return Ok();
            };

            return PerformOperation(operation);
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(Student student)
        {
            _operationName = "Update Student";

            Func<IHttpActionResult> operation = () =>
            {
                _studentRepository.UpdateStudent(student);
                return Ok();
            };
            return PerformOperation(operation);
        }

        private IHttpActionResult PerformOperation(Func<IHttpActionResult> operation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return operation();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error performing operation: {0}", _operationName), ex.InnerException);
            }
            return BadRequest(ModelState);
        }
    }
}