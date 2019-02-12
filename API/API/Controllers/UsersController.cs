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
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserOperations _operations;
        MediaTypeFormatter _formatter;
        public UsersController(IUserOperations op)
        {
            _operations = op;
            _formatter = new JsonMediaTypeFormatter();
        }
        [HttpGet]
        public HttpResponseMessage Get([FromBody] UserFilterModel filter)
        {
            try
            {
                var users = _operations.GetUsers(filter);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<IEnumerable<UserViewModel>>(users, _formatter)
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
                var user = _operations.GetUser(id);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<UserModel>(user, _formatter)
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
        public HttpResponseMessage Post([FromBody] UserModel user)
        {
            try
            {
                var registeredUser = _operations.RegisterUser(user);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<UserModel>(user, _formatter)
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
        public HttpResponseMessage Put(int id, [FromBody] UserModel user)
        {
            try
            {
                user.Id = id;
                _operations.UpdateUser(user);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent($"User {id} updated")
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
                _operations.DeleteUser(id);
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent($"User {id} updated")
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
