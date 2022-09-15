using MediatR;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
	public class AddUserRequest: IRequest<UserModel>
	{
        public string Name { get; set; }
		public string Comment { get; set; }
	}
}
