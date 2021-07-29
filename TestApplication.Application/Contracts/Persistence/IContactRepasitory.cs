using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Domain.Entities;

namespace TestApplication.Application.Contracts.Persistence
{
    public interface IContactRepasitory : IAsyncRepository<Contact>
    {

    }
}
