using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Services
{
	public interface IUserService
    {
        UserModel AddUser(UserModel user);
    }
}
