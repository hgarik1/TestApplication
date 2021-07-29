using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApplication.Application.Contracts.Persistence;
using TestApplication.Application.Features.Contacts.Queries.Models;

namespace TestApplication.Application.Features.Contacts.Queries.GetContactsList
{
    public class GetContactListQueryHandler : IRequestHandler<GetContactListQuery, List<ContactViewModel>>
    {
        private readonly IContactRepasitory _contactRepository;
        private readonly IMapper _mapper;

        public GetContactListQueryHandler(IMapper mapper, IContactRepasitory contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }


        public async Task<List<ContactViewModel>> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            var allContacts = await _contactRepository.ListAllAsync();
            return _mapper.Map<List<ContactViewModel>>(allContacts);
        }
    }
}
