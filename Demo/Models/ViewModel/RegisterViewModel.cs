using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { set; get; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { set; get; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { set; get; }

        public string RegIp { set; get; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }
    }
}
