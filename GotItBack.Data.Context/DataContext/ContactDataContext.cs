using System.Data.Entity;
using GotItBack.Data.Objects.Entities;

namespace GotItBack.Data.Context.DataContext
{
    public class ContactDataContext : DbContext
    {
        public ContactDataContext()
            : base("name=SAAS-OPMAS")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}