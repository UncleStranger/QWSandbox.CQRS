using MediatR;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
	public class AddUserNotificationHandler: INotificationHandler<AddUserNotification>
	{
        public Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            return Task.CompletedTask;
        }
    }
}
