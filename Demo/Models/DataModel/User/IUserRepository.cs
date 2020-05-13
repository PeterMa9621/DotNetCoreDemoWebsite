using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models.DataModel.User
{
    interface IUserRepository
    {
        public UserEntity GetOneUser(string userName);
    }
}
