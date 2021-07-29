using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Application.Features.Contacts.Commands.CreateContact;
using TestApplication.Application.Features.Contacts.Commands.DeleteContact;
using TestApplication.Application.Features.Contacts.Commands.UpdateContact;
using TestApplication.Application.Features.Contacts.Queries.GetContact;
using TestApplication.Application.Features.Contacts.Queries.GetContactsList;
using TestApplication.Application.Features.Contacts.Queries.Models;

namespace TestApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ContactViewModel>>> GetAllContacts()
        {
            var dtos = await _mediator.Send(new GetContactListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactViewModel>> GetEventById(int id)
        {
            var getContactQuery = new GetContactQuery() { Id = id };
            return Ok(await _mediator.Send(getContactQuery));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create([FromBody] CreateContactCommand createContactCommand)
        {
            var id = await _mediator.Send(createContactCommand);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateContactCommand updateContactCommand)
        {
            await _mediator.Send(updateContactCommand);
            return NoContent();
        }

        [HttpDelete("Delete/{id}", Name = "DeleteContact")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteContactCommand = new DeleteContactCommand() { Id = id };
            await _mediator.Send(deleteContactCommand);
            return NoContent();
        }

    }
}
