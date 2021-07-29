using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Domain.Common;

namespace TestApplication.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string PhysicalAddress { get; set; }

    }
}
