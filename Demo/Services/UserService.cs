using Demo.Models.DataModel.Repository;
using Demo.Models.DataModel.User;
using Demo.Models.ViewModel;
using Demo.Util;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class UserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManger;
        public UserService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManger = signInManager;
        }
        public async Task<bool> Add(RegisterViewModel model)
        {
            try
            {
                long timestamp = TimeUtil.GetNowTimeStamp();
                UserEntity user = new UserEntity()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    RegIp = model.RegIp,
                    RegDate = timestamp
                };
                string password = model.Password;
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                    return true;
                else
                    return false;
                /*
                UserEntity checkUser = userRepository.GetOneUser(user.UserName);
                if (checkUser != null)
                    return false;
                userRepository.Add(user);
                userRepository.Save();
                */
            } catch(Exception)
            {
                return false;
            }
            
        }

        public async Task<UserEntity> Get(string userName)
        {
            UserEntity userEntity = await _userManager.FindByNameAsync(userName);
            return userEntity;
        }

        public async Task<UserEntity> Get(ClaimsPrincipal claimsPrincipal)
        {
            UserEntity userEntity = await _userManager.GetUserAsync(claimsPrincipal);
            return userEntity;
        }

        public async Task<bool> UpdateAsync(UserEntity userEntity)
        {
            var result = await _userManager.UpdateAsync(userEntity);
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<bool> SignIn(string username, string password)
        {
            UserEntity userEntity = await _userManager.FindByNameAsync(username);
            var result = await _signInManger.PasswordSignInAsync(userEntity, password, false, false);
            if(result.Succeeded)
            {
                return true;
            }
            //UserEntity userEntity = userRepository.GetOneUser(username);
            /*
            if (userEntity == null)
                return null;
            if (userEntity.Password != password)
                return null;
                */
            return false;
        }

        public async void SignOut()
        {
            await _signInManger.SignOutAsync();
        }
    }
}
