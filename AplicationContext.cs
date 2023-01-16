using Models;
using Microsoft.EntityFrameworkCore;

namespace ContextAplication;
public partial class AplicationContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<MovieGender> MovieGenders { get; set; }
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

        modelBuilder.Entity<Gender>(gender =>{
            gender.ToTable("Gender");
            gender.HasKey(p => p.GenderId);
        });

        modelBuilder.Entity<UserMovie>(userMovie => {
            userMovie.ToTable("UserMovie");
            userMovie.Property(p => p.Id)
            .ValueGeneratedOnAdd(); 
        });

        modelBuilder.Entity<MovieGender>(movieGender =>{
            movieGender.ToTable("MovieGender");
            movieGender.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        });

           //--------------------Relations--MovieGender
        modelBuilder.Entity<MovieGender>()
            .HasOne(a => a.Movie)
            .WithMany(b => b.MovieGenders)
            .HasForeignKey(c => c.MovieId);
            
        modelBuilder.Entity<MovieGender>()
            .HasOne(a => a.Gender)
            .WithMany(b => b.MovieGenders)
            .HasForeignKey(c => c.GenderId);
        //-------------------- Relations--UserMovie
        modelBuilder.Entity<UserMovie>()
            .HasOne(a => a.User)
            .WithMany(b => b.UserMovies)
            .HasForeignKey(c => c.UserId);
        
        modelBuilder.Entity<UserMovie>()
            .HasOne(a => a.Movie)
            .WithMany(b => b.UserMovies)
            .HasForeignKey(c => c.MovieId);
        //-----------------------------------------

    }

}