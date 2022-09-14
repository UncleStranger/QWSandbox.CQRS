using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediatr.User
{
	public class AddUserCommandHandler: IRequestHandler<AddUserCommand, UserModel>
	{
        public AddUserCommandHandler(/*Inject services*/)
        {
            
        }

        public Task<UserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
