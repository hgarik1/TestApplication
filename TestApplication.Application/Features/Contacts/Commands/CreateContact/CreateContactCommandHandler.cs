using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApplication.Application.Contracts.Persistence;
using TestApplication.Application.Exceptions;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Features.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepasitory _contactRepasitory;
        private readonly IMapper _mapper;
        public CreateContactCommandHandler(IMapper mapper,IContactRepasitory contactRepasitory)
        {
            _mapper = mapper;
            _contactRepasitory = contactRepasitory;
        }
        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateContactCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            var @contact = _mapper.Map<Contact>(request);
            @contact = await _contactRepasitory.AddAsync(@contact);
            return @contact.Id;
        }
    }
}
