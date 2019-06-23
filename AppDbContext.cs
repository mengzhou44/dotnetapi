using Microsoft.EntityFrameworkCore;


namespace dotnetapi
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {

        }

        public virtual DbSet<Feeds> Feeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feeds>(entity =>
            {
                entity.ToTable("feeds");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.Source).HasColumnName("source");
                entity.Property(e => e.Name).HasColumnName("name");

            });

        }
    }
}
