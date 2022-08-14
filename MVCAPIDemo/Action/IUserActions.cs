using MVCAPIDemo.Models;

namespace MVCAPIDemo.Action
{
    public interface IUserActions
    {
        UserInfo CheckLogin(string userNo, string password);

        string AddUser(UserInfo user);

        string UpdateUser(string userNo, string name, int age, string pwd);

        string DeleteUser(string userNo);

        List<UserInfo> GetAllUser();

    }
}
