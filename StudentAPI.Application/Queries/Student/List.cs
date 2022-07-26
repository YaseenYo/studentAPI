using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Queries.Student
{
    public class List
    {
        public class Query : IRequest<IEnumerable<Domain.Entities.Student>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<Domain.Entities.Student>>
        {
            private readonly IStudentRepository _repository;

            public Handler(IStudentRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Domain.Entities.Student>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}

