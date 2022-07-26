using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Application.Command.Student;
using StudentAPI.Application.Queries.Student;
using StudentAPI.Domain.Entities;

namespace StudentAPI.API.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(string id)
        {
            var res = await _mediator.Send(new Detail.Query() { Id = id });

            if (res == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student Student)
        {
            await _mediator.Send(new Create.Command() { Student = Student });

            return CreatedAtAction(nameof(Get), new { id = Student.Id }, Student);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Student Student)
        {
            var exisitingStudent = await _mediator.Send(new Detail.Query() { Id = Student.Id });
            if (exisitingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            await _mediator.Send(new Update.Command() { Student = Student });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var exisitingStudent = await _mediator.Send(new Detail.Query() { Id = id });
            if (exisitingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            await _mediator.Send(new Delete.Command() { Id = id });
            return Ok($"Student with id = {id} deleted");
        }
    }
}

