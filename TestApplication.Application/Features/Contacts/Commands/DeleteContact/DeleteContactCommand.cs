using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Application.Features.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }
    }
}
