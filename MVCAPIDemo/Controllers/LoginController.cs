using Microsoft.AspNetCore.Mvc;
using MVCAPIDemo.Action;
using MVCAPIDemo.Models;

namespace MVCAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserActions userActions;

        public LoginController(IUserActions userActions)
        {
            this.userActions = userActions;
        }

        [HttpGet]
        public List<UserInfo> GetAll()
        {
            List<UserInfo> userList = userActions.GetAllUser();
            return userList;
        }

        //[HttpGet("{userNo}/{password}")]
        //public UserInfo GetLoginRes(string userNo, string password)
        //{
        //    UserInfo user = userActions.CheckLogin(userNo, password);
        //    return user;
        //}

        [HttpPost]
        public string Insert(UserInfo user)
        {
            return userActions.AddUser(user);
        }

        [HttpPut]
        public string Update(string userNo, string userName, int age, string password)
        {
            return userActions.UpdateUser(userNo, userName, age, password);
        }

        [HttpDelete]
        public string Remove(string userNo)
        {
            return userActions.DeleteUser(userNo);
        }
    }
}
