using System.Diagnostics;
using AutoMapper;
using MediatR;
using QWSandbox.CQRS.Domain.Models.User;
using QWSandbox.CQRS.Web.Services;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
	public class GetUsersRequestHandler: IRequestHandler<GetUsersRequest, List<UserModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUserCacheService _userCacheService;
        private readonly IUserDBService _userDbService;
        private readonly ILogger<GetUsersRequestHandler> _logger;
        public GetUsersRequestHandler(IMapper mapper, 
            IUserCacheService userCacheService, 
            IUserDBService userDbService,
            ILogger<GetUsersRequestHandler> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userCacheService = userCacheService ?? throw new ArgumentNullException(nameof(userCacheService));
            _userDbService = userDbService ?? throw new ArgumentNullException(nameof(userDbService));
            _logger = logger ?? throw new NotImplementedException(nameof(logger));
        }

        /// <summary>
        /// ВАЖНО: Отработает только последний, зарегистрированный в DI контейнере Handler.
        /// Как контролировать их очередность не понятно. Наличие нескольких Handler не вызовет ошибки.
        ///
        /// Можно при запуске проекта получить все IRequestHandler и проверять в ручную.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<UserModel>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetUserRequestHandler executed.");

            List<UserModel> users = await _userCacheService.GetUsers();
            if (users == null || !users.Any())
            {
                users = await _userDbService.GetUsers();
                foreach (UserModel user in users)
                {
                    await _userCacheService.AddUser(user);
                }
            }

            return users;
        }
    }
}
