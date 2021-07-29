using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Application.Features.Contacts.Queries.Models;

namespace TestApplication.Application.Features.Contacts.Queries.GetContactsList
{
    public class GetContactListQuery :IRequest<List<ContactViewModel>>
    {

    }
}
