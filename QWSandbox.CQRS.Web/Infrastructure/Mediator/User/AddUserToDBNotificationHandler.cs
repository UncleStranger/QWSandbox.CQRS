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
        private readonly IUserCacheService _userCacheService;
        private readonly IMapper _mapper;
        public AddUserToDBNotificationHandler(IMapper mapper, IUserDBService userDBService, IUserCacheService userCacheService)
        {
            _userDBService = userDBService ?? throw new ArgumentNullException(nameof(userDBService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            if(Debugger.IsAttached)
                Debugger.Break();

            var user = _mapper.Map<UserModel>(notification);
            await _userDBService.AddUser(user);
            await _userCacheService.AddUser(user);
        }
    }
}
