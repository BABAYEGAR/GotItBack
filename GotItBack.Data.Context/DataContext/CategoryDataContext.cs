using System.Data.Entity;
using GotItBack.Data.Objects.Entities;

namespace GotItBack.Data.Context.DataContext
{
    public class CategoryDataContext : DbContext
    {
        public CategoryDataContext()
            : base("name=GotItBack")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}