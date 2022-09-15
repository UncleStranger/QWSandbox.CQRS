using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Services.Default
{
	public class UserService : IUserService
	{
        public UserModel AddUser(UserModel user)
        {
            if(Debugger.IsAttached)
                Debugger.Break();
            throw new NotImplementedException();
        }
    }
}
