using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApplication.Domain.Common;
using TestApplication.Domain.Entities;

namespace TestApplication.Persistance
{
    public class TestApplicationDbContext : DbContext
    {
        public TestApplicationDbContext(DbContextOptions<TestApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestApplicationDbContext).Assembly);

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 1,
                FullName = "Garik",
                EmailAddress = "garik@mail.com",
                PhoneNumber = "+37455",
                PhysicalAddress = "Komitas 15"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                Id = 2,
                FullName = "Serg",
                EmailAddress = "serg@mail.com",
                PhoneNumber = "+37491",
                PhysicalAddress = "Papazyan 14"
            });
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
