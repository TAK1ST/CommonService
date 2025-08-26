using CommonService.Application.Features.Users.Commands;
using CommonService.Application.Interfaces.IRepositories;
using CommonService.Domain.Entities;
using MediatR;

namespace CommonService.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password // In a real application, ensure to hash the password
            };
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
