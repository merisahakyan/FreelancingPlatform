using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Core.Models.BusinessModels;
using Core.Models.FilterModels;
using Core.Models.ViewModels;
using Core.OperationInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        IWorkOperations _operations;
        MediaTypeFormatter _formatter;
        public WorksController(IWorkOperations op)
        {
            _operations = op;
            _formatter = new JsonMediaTypeFormatter();
        }
        [HttpGet]
        public HttpResponseMessage Get([FromQuery] WorkFilterModel filter)
        {
            try
            {
                var works = _operations.GetWorks(filter).ToList();
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<List<WorkViewModel>>(works, _formatter)
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var work = _operations.GetWork(id);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<WorkModel>(work, _formatter)
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] WorkModel work)
        {
            try
            {
                var registeredUser = _operations.CreateWork(work);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<WorkModel>(work, _formatter)
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] WorkModel work)
        {
            try
            {
                work.Id = id;
                _operations.UpdateWork(work);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent($"Work {id} updated")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _operations.DeleteWork(id);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent($"Work {id} deleted")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        [HttpPut("{userId}/{workId}/{rate:decimal}")]
        public HttpResponseMessage HireUser(int userId, int workId, decimal rate)
        {
            try
            {
                var hireResult = _operations.Hire(userId, workId, rate);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<UserWorkModel>(hireResult, _formatter)
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }

        [HttpPut("{userId}/{workId}")]
        public HttpResponseMessage BreakContract(int userId, int workId)
        {
            try
            {
                var breakResult = _operations.BreakContract(userId, workId);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<UserWorkModel>(breakResult, _formatter)
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                };
            }
        }
    }
}