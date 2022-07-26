using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Queries.Credentials
{
    public class List
    {
        public class Query : IRequest<IEnumerable<Domain.Entities.Credentials>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<Domain.Entities.Credentials>>
        {
            private readonly ICredentialsRepository _repository;

            public Handler(ICredentialsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Domain.Entities.Credentials>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}

