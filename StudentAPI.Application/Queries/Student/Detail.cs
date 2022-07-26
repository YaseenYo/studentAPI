using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Queries.Student
{
    public class Detail
    {
        public class Query : IRequest<Domain.Entities.Student>
        {
            public string Id { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Query, Domain.Entities.Student>
        {
            private readonly IStudentRepository _repository;

            public Handler(IStudentRepository repository)
            {
                _repository = repository;
            }

            public async Task<Domain.Entities.Student> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetStudentByIdAsync(request.Id);
            }
        }
    }
}

