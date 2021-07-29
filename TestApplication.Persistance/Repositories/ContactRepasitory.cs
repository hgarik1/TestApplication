using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Application.Contracts.Persistence;
using TestApplication.Domain.Entities;

namespace TestApplication.Persistance.Repositories
{
    public class ContactRepasitory :BaseRepository<Contact>,IContactRepasitory
    {
        public ContactRepasitory(TestApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
