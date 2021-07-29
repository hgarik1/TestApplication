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

namespace TestApplication.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IAsyncRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public DeleteContactCommandHandler(IMapper mapper, IAsyncRepository<Contact> contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }
        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contactToDelete = await _contactRepository.GetByIdAsync(request.Id);
            if (contactToDelete == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            _mapper.Map(request, contactToDelete, typeof(DeleteContactCommand), typeof(Contact));

            await _contactRepository.DeleteAsync(contactToDelete);

            return Unit.Value;
        }
    }
}
