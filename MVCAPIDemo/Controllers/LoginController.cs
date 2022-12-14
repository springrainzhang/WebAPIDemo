using Microsoft.AspNetCore.Mvc;
using MVCAPIDemo.Action;
using MVCAPIDemo.Models;

namespace MVCAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("[controller]/[Action]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserActions userActions;
        private readonly ILogger<LoginController> logger;

        public LoginController(IUserActions userActions, ILogger<LoginController> logger)
        {
            this.userActions = userActions;
            this.logger = logger;
        }

        [HttpGet]
        public List<UserInfo> GetAll()
        {
            List<UserInfo> userList = userActions.GetAllUser();
            logger.LogInformation(new EventId(1001), "Get all user");
            return userList;
        }

        [HttpGet]
        [Route("{userNo:int}/{password=111}")]
        public UserInfo GetLoginRes(string userNo, string password)
        {
            UserInfo user = userActions.CheckLogin(userNo, password);
            return user;
        }

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
