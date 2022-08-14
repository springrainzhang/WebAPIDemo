using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAPIDemo.Models
{
    [Table(nameof(UserInfo))]
    public class UserInfo
    {
        [Key]
        public string UserNo{ get; set; } 

        public string Name { get; set; }

        public int Age { get; set; }

        public string Pwd { get; set; }

        public bool IsDelete { get; set; }

    }
}
