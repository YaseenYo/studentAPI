using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Queries.getCredentials
{
    public class Detail
    {
        public class Query : IRequest<Domain.Entities.Credentials>
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Query, Domain.Entities.Credentials>
        {
            private readonly ICredentialsRepository _repository;

            public Handler(ICredentialsRepository repository)
            {
                _repository = repository;
            }

            public async Task<Domain.Entities.Credentials> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetCredentialsByIdAsync(request.Id);
            }
        }
    }
}

