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
        private readonly ILogger<AddUserToCacheNotificationHandler> _logger;

        public AddUserToCacheNotificationHandler(IMapper mapper, IUserCacheService userCacheService, ILogger<AddUserToCacheNotificationHandler> logger)
        {
            _userCacheService = userCacheService ?? throw new ArgumentNullException(nameof(userCacheService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new NotImplementedException(nameof(logger));
        }
        
        public Task Handle(AddUserNotification notification, CancellationToken cancellationToken)
        {
            if(Debugger.IsAttached)
                Debugger.Break();


            // a.evdokimov this may throw exception in background thread (?)
            var user = _mapper.Map<UserModel>(notification);

            _logger.LogInformation("AddUserToCacheNotificationHandler add user {user} to UserCacheService.", notification);

            return _userCacheService.AddUser(user);
        }
    }
}
