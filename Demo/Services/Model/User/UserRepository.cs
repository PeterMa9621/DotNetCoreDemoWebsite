using Demo.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Models.Repository
{
    public class UserRepository : GenericRepository<UserContext, UserEntity>, IUserRepository
    {
        public UserEntity GetOneUser(string userName)
        {
            Expression<Func<UserEntity, bool>> predicate = userEntity => userEntity.UserName == userName;
            IQueryable<UserEntity> userEntities = FindBy(predicate);
            if (userEntities.Count() == 0)
                return null;
            UserEntity user = userEntities.First();
            return user;
        }
    }
}
