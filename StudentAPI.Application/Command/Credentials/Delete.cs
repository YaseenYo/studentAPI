using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Command.Credentials
{
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICredentialsRepository _repository;

            public Handler(ICredentialsRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.DeleteCredentials(request.Id);
                return Unit.Value;
            }
        }
    }
}

