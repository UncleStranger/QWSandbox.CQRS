using System.Diagnostics;
using AutoMapper;
using MediatR;
using QWSandbox.CQRS.Domain.Models.User;
using QWSandbox.CQRS.Web.Services;
using QWSandbox.CQRS.Web.Services.Default;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
	public class AddUserToDBNotificationHandler: INotificationHandler<AddUserNotification>
	{
        private readonly IUserDBService _userDBService;
        private readonly IMapper _mapper;
        private readonly ILogger<AddUserToDBNotificationHandler> _logger;
        public AddUserToDBNotificationHandler(IMapper mapper, IUserDBService userDBService, ILogger<AddUserToDBNotificationHandler> logger)
        {
            _userDBService = userDBService ?? throw new ArgumentNullException(nameof(userDBService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new NotImplementedException(nameof(logger));
        }

        public async Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            if(Debugger.IsAttached)
                Debugger.Break();

            var user = _mapper.Map<UserModel>(notification);

            _logger.LogInformation("AddUserToDBNotificationHander: add user {user} to UserDBService.", user);

            await _userDBService.AddUser(user);
        }
    }
}
