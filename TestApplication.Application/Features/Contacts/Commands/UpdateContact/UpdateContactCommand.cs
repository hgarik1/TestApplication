using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Application.Features.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string PhysicalAddress { get; set; }

    }
}
