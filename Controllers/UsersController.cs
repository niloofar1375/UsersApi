using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UsersApi.Models;
using UsersApi.Dtos;
using System;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private StudentContext _StudentContext;

        public UsersController(StudentContext context)
        {
            _StudentContext = context;
        }

        ~UsersController()
        {
            _StudentContext.Dispose();
        }

        [Route("signup")]
        [HttpPost]
        public bool Signup([FromBody]User user)
        {
            try
            {
                var userList = _StudentContext.Users.Add(user);
                _StudentContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                var erroMsg = ex.Message.ToString();
                return false;
            }
        }

        [Route("login")]
        [HttpPost]
        public bool Login([FromBody]Login login)
        {
            var userList = _StudentContext.Users.Where(t => t.UserName == login.UserName && t.Password == login.Password).ToList();
            if (userList.Count > 0)
                return true;
            else
                return false;
        }
        [Route("getusers")]
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var getList = _StudentContext.Users.OrderBy(s => s.FirstName).ToList();
            return getList;
        }
    }
}
