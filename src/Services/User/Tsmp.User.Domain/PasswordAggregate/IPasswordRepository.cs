using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tsmp.User.Domain.PasswordAggregate
{
    public interface IPasswordRepository
    {
        Task CreatePassword(PasswordEntity passwordEntity);
    }
}
