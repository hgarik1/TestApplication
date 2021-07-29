using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Application.Features.Contacts.Commands.CreateContact;
using TestApplication.Application.Features.Contacts.Commands.DeleteContact;
using TestApplication.Application.Features.Contacts.Commands.UpdateContact;
using TestApplication.Application.Features.Contacts.Queries.Models;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, CreateContactCommand>().ReverseMap();
            CreateMap<Contact, UpdateContactCommand>().ReverseMap();
            CreateMap<Contact, DeleteContactCommand>().ReverseMap();
            CreateMap<Contact, ContactViewModel>().ReverseMap();
        }
    }
}
