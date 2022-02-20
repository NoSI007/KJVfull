using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace KJVfull
{
    public partial class KJVDataContext : DbContext
    {
        public KJVDataContext()
            : base("name=KJVData")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BSection> BSections { get; set; }
        public virtual DbSet<Matrix> Matrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
