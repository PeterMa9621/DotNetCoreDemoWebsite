using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.DataModel.User
{
    public class UserEntity : IdentityUser
    {
        public string Ip { get; set; }
        public long LastLogin { get; set; }
        public long RegDate { get; set; }
        public string RegIp { get; set; }
        public bool Session { get; set; }
    }
}
