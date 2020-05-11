using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.User
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Ip { get; set; }
        public long LastLogin { get; set; }
        public long RegDate { get; set; }
        public string RegIp { get; set; }
        public string Email { get; set; }
        public bool Session { get; set; }
    }
}
