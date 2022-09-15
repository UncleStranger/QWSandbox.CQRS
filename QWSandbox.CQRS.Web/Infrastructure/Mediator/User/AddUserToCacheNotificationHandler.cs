using System.Diagnostics;
using AutoMapper;
using MediatR;
using QWSandbox.CQRS.Domain.Models.User;
using QWSandbox.CQRS.Web.Services;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
	public class AddUserToCacheNotificationHandler: INotificationHandler<AddUserNotification>
    {
        private readonly IUserCacheService _userCacheService;
        private readonly IMapper _mapper;
        public AddUserToCacheNotificationHandler(IMapper mapper, IUserCacheService userCacheService)
        {
            _userCacheService = userCacheService ?? throw new ArgumentNullException(nameof(userCacheService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            if(Debugger.IsAttached)
                Debugger.Break();

            var user = _mapper.Map<UserModel>(notification);
            return _userCacheService.AddUser(user);
        }
    }
}
