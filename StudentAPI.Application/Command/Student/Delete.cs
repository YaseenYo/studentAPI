using System;
using MediatR;
using StudentAPI.Infrastructure.Services;

namespace StudentAPI.Application.Command.Student
{
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; } = string.Empty;
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
                await _repository.DeleteStudent(request.Id);
                return Unit.Value;
            }
        }
    }
}

