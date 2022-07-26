using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Command.Student
{
    public class Create
    {
        public class Command : IRequest
        {
            public Domain.Entities.Student? Student { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly IStudentRepository _repository;

            public Handler(IStudentRepository repository)
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.AddAsync(request.Student);

                return Unit.Value;
            }
        }
    }
}

