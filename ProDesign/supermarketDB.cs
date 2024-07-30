using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProDesign
{
    public partial class supermarketDB : DbContext
    {
        public supermarketDB()
            : base("name=supermarketDB")
        {
        }

        public virtual DbSet<Table1> Table1 { get; set; }
        public virtual DbSet<Table2> Table2 { get; set; }
        public virtual DbSet<Table3> Table3 { get; set; }
        public virtual DbSet<Table4> Table4 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Table2>()
                .HasOptional(e => e.Table3)
                .WithRequired(e => e.Table2);
        }
    }
}
