using System.Data.Entity;
using GotItBack.Data.Objects.Entities;

namespace GotItBack.Data.Context.DataContext
{
    public class FoundItemDataContext : DbContext
    {
        public FoundItemDataContext()
            : base("name=GotItBack")
        {
        }

        public virtual DbSet<FoundItem> FoundItems { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}