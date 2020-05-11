using Demo.Models.Repository;
using Demo.Models.User;
using Demo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class UserService
    {
        private readonly UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }
        public bool Add(UserEntity user, String regIp)
        {
            try
            {
                DateTime now = DateTime.Now;
                long timestamp = TimeUtil.GetTimeStamp(now);
                user.RegIp = regIp;
                user.RegDate = timestamp;
                UserEntity checkUser = userRepository.GetOneUser(user.UserName);
                if (checkUser != null)
                    return false;
                userRepository.Add(user);
                userRepository.Save();
                return true;
            } catch(Exception e)
            {
                return false;
            }
            
        }
        public IEnumerable<UserEntity> Get()
        {
            return userRepository.GetAll().ToArray();
        }

        public UserEntity Get(string userName)
        {
            return userRepository.GetOneUser(userName);
        }

        public UserEntity GetMatchedUser(string username, string password)
        {
            UserEntity userEntity = userRepository.GetOneUser(username);
            if (userEntity == null)
                return null;
            if (userEntity.Password != password)
                return null;
            return userEntity;
        }
    }
}
