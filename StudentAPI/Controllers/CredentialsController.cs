using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Application.Command.Credentials;
using StudentAPI.Application.Queries.Credentials;
using StudentAPI.Application.Queries.getCredentials;
using StudentAPI.Domain.Entities;

namespace StudentAPI.API.Controllers
{
    [Route("api/Credentials")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CredentialsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<ActionResult<List<Credentials>>> Get()
        {
            return Ok(await _mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Credentials>> Get(string id)
        {
            var res = await _mediator.Send(new Detail.Query() { Id = id });

            if (res == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return res;
        }

        [HttpPost]
        public async Task<ActionResult<Credentials>> Post([FromBody] Credentials Credentials)
        {
            await _mediator.Send(new Create.Command() { Credentials = Credentials });

            return CreatedAtAction(nameof(Get), new { id = Credentials.Id }, Credentials);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Credentials Credentials)
        {
            var exisitingCredentials = await _mediator.Send(new Detail.Query() { Id = Credentials.Id });
            if (exisitingCredentials == null)
            {
                return NotFound($"Credentials with Id = {id} not found");
            }
            await _mediator.Send(new Update.Command() { Credentials = Credentials });
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var exisitingCredentials = await _mediator.Send(new Detail.Query() { Id = id });
            if (exisitingCredentials == null)
            {
                return NotFound($"Credentials with Id = {id} not found");
            }
            await _mediator.Send(new Delete.Command() { Id = id });
            return Ok($"Student with id = {id} deleted");
        }
    }
}

