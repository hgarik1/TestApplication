using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TestApplication.Application.Contracts.Persistence;
using TestApplication.Application.Exceptions;
using TestApplication.Application.Features.Contacts.Queries.Models;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Features.Contacts.Queries.GetContact
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactViewModel>
    {
        private readonly IContactRepasitory _contactRepository;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(IMapper mapper, IContactRepasitory contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task<ContactViewModel> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var @contact = await _contactRepository.GetByIdAsync(request.Id);

            if (contact == null)
            {
                throw new NotFoundException(nameof(Contact), request.Id);
            }

            return _mapper.Map<ContactViewModel>(@contact); 
        }
    }
}
