using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library_Management_System.Models
{
    public partial class MyLibraryContext : DbContext
    {
        public MyLibraryContext()
        {
        }

        public MyLibraryContext(DbContextOptions<MyLibraryContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=tcp:library-management3-systemdbserver.database.windows.net,1433;Initial Catalog=Library_Management_System3_db;User Id=jasneetkaur;Password=Jk123456789!");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<IssueDetails> IssueDetail { get; set; }
    }
}
