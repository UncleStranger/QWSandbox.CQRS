using MediatR;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
	public class GetUsersRequest: IRequest<List<UserModel>>
	{
        
	}
}
