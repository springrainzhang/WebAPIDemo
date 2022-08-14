using MVCAPIDemo.Common;
using MVCAPIDemo.Models;

namespace MVCAPIDemo.Action.Impl
{
    public class UserActions : IUserActions
    {
        private MyDataContext db;
        public UserActions()
        {
            db = new MyDataContext("WebAPIData.db");
        }


        public string AddUser(UserInfo user)
        {
            db.Add(user);
            var res = db.SaveChanges();
            if(res == 0)
            {
                return "add user success";
            } 
            else
            {
                return "add user failed";
            }
        }

        public UserInfo CheckLogin(string userNo, string password)
        {
            var user = db.Users.Where(u => u.UserNo == userNo && u.Pwd == password).FirstOrDefault();
            if(user != null)
            {
                return user;
            }
            else
            {
                return new UserInfo();
            }
        }

        public string DeleteUser(string userNo)
        {
            var user = db.Users.Where(u => u.UserNo == userNo).FirstOrDefault();
            if (user != null)
            {
                user.IsDelete = true;
            }

            var res = db.SaveChanges();
            if (res == 1)
            {
                return "Delete user success";
            }
            else
            {
                return "Delete user failed";
            }
        }

        public List<UserInfo> GetAllUser()
        {
            return db.Users.ToList();
        }

        public string UpdateUser(string userNo, string name, int age, string pwd)
        {
            var user = db.Users.Where(u => u.UserNo == userNo).FirstOrDefault();
            if(user != null)
            {
                user.Name = name;
                user.Age = age;
                user.Pwd = pwd;
            }
            else
            {
                user = new UserInfo() { UserNo = userNo, Name = name, Age = age, Pwd = pwd, IsDelete = false};
                this.AddUser(user);
            }

            var res = db.SaveChanges();
            if (res == 1)
            {
                return "Update user success";
            }
            else
            {
                return "Create user success";
            }
        }
    }
}
