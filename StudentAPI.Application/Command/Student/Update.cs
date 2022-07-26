using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Command.Student
{
    public class Update
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
                await _repository.UpdateStudentAsync(request.Student.Id, request.Student);

                return Unit.Value;
            }
        }
    }
}

