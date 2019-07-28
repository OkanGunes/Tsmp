using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tsmp.User.Domain.UserAggregate
{
    public interface IUserRepository
    {
        Task CreateUser(UserEntity userEntity);
    }
}
