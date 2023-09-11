using Microsoft.EntityFrameworkCore;
using WebBlog.Models;

namespace WebBlog.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Blogs)
            .HasForeignKey(d => d.Author_Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Blog>()
            .HasOne(b => b.Genre)
            .WithMany(a => a.Blogs)
            .HasForeignKey(d => d.Genre_Id)
            .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Blog> Blogs { get; set;}
        public DbSet<Author> Authors { get; set;}
        public DbSet<Genre> Genres { get; set;}
    }
}
