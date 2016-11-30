using System.Data.Entity;
using GotItBack.Data.Objects.Entities;

namespace GotItBack.Data.Context.DataContext
{
    public class LgaDataContext : DbContext
    {
        public LgaDataContext()
            : base("name=GotItBack")
        {
        }

        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Lga> Lgas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}