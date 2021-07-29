using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Domain.Entities;

namespace TestApplication.Persistance.Configutartion
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhysicalAddress)
                .HasMaxLength(50);

        }
    }
}
