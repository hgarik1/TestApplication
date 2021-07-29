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

namespace TestApplication.Application.Features.Contacts.Commands.UpdateContact
{

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IAsyncRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;
        public UpdateContactCommandHandler(IMapper mapper, IAsyncRepository<Contact> contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contactToUpdate = await _contactRepository.GetByIdAsync(request.Id);
            if (contactToUpdate == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            var validator = new UpdateContactCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, contactToUpdate, typeof(UpdateContactCommand), typeof(Contact));

            await _contactRepository.UpdateAsync(contactToUpdate);

            return Unit.Value;
        }
    }
}

