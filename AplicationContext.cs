using Models;
using Microsoft.EntityFrameworkCore;

namespace ContextAplication;
public partial class AplicationContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<UserMovie> UserMovies { get; set; }

    public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>(user => //cuidado!!
        {
          user.ToTable("User");
          user.HasKey(p => p.UserId);
          user.Property(p => p.UserId).ValueGeneratedOnAdd();
          user.Property(p => p.Name).HasMaxLength(150).IsRequired();
          user.Property(p => p.Email).IsRequired();
          user.Property(p => p.Identification).IsRequired();
          user.Property(p => p.Pass).IsRequired();
          user.Property(p => p.Adress).IsRequired();
        });

        modelBuilder.Entity<Movie>(movie =>{
            movie.ToTable("Movie");
            movie.HasKey(p => p.MovieId);
        });

        
        //-------------------- Relations--UserMovie
        modelBuilder.Entity<UserMovie>().HasKey(t => new {t.UserId,t.MovieId});
        modelBuilder.Entity<UserMovie>()
            .HasOne(pt => pt.User)
            .WithMany(p => p.UserMovies)
            .HasForeignKey(pt => pt.UserId);
        
        modelBuilder.Entity<UserMovie>()
            .HasOne(pt => pt.Movie)
            .WithMany(p => p.UserMovies)
            .HasForeignKey(pt => pt.MovieId);
        //-----------------------------------------

    }

}