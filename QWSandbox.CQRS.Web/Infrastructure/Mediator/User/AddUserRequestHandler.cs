using AutoMapper;
using MediatR;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Infrastructure.Mediator.User
{
	public class AddUserRequestHandler: IRequestHandler<AddUserRequest, UserModel>
    {
        private readonly IMapper _mapper;
        public AddUserRequestHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException();
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
        public Task<UserModel> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {

            var user = 
            return Task.FromResult(new UserModel());
        }
    }
}
