using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Command.Credentials
{
    public class Create
    {
        public class Command : IRequest
        {
            public Domain.Entities.Credentials? Credentials { get; set; }
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
                await _repository.AddAsync(request.Credentials);

                return Unit.Value;
            }
        }
    }
}

