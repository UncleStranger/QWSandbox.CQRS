using QWSandbox.CQRS.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWSandbox.CQRS.Web.Services
{
    public interface IUserService
    {
        Task AddUser(UserModel user);
        Task<List<UserModel>> GetUsers();
        Task<UserModel> GetUser(Guid id);
    }
}
