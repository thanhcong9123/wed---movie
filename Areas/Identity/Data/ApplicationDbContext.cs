using AppFilm.Net.Areas.Identity.Data;
using AppFilm.Net.Models;
using FilmWed.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmWed.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
             modelBuilder.Entity<PeopleDirectorConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdPeople
            });
            modelBuilder.Entity<PeoplePerformerConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdPeople
            });
            modelBuilder.Entity<NationConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdNation
            });
            modelBuilder.Entity<GenreConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdGenre
            });

            modelBuilder.Entity<SeasonsConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdSeason
            });
            modelBuilder.Entity<TrailersConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdTrailer
            });
            modelBuilder.Entity<PeopleConnJob>().HasKey(am => new
            {
                am.IdJob,
                am.IdPeople
            });
            modelBuilder.Entity<PeopleDirectorConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdPeople
            });
            modelBuilder.Entity<PeoplePerformerConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdPeople
            });
            modelBuilder.Entity<NationConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdNation
            });
            modelBuilder.Entity<GenreConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdGenre
            });

            modelBuilder.Entity<SeasonsConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdSeason
            });
            modelBuilder.Entity<TrailersConnMovie>().HasKey(am => new
            {
                am.IdMovie,
                am.IdTrailer
            });
            modelBuilder.Entity<CollectionMovies>().HasKey(am => new
            {
                am.IdMovie,
                am.IdUser
            });
            modelBuilder.Entity<PeopleDirectorConnMovie>().HasOne(m => m.Movie).WithMany(mtp => mtp.PeopleDirectorConnMovies).HasForeignKey(m => m.IdMovie);
            modelBuilder.Entity<PeoplePerformerConnMovie>().HasOne(m => m.Movie).WithMany(mtp => mtp.PeoplePerformerConnMovies).HasForeignKey(m => m.IdMovie);
            modelBuilder.Entity<NationConnMovie>().HasOne(m => m.Movie).WithMany(mtp => mtp.NationConnMovies).HasForeignKey(m => m.IdMovie);
            modelBuilder.Entity<GenreConnMovie>().HasOne(m => m.Movie).WithMany(mtp => mtp.GenreConnMovies).HasForeignKey(m => m.IdMovie);
            modelBuilder.Entity<SeasonsConnMovie>().HasOne(m => m.Movie).WithMany(mtp => mtp.SeasonsConnMovies).HasForeignKey(m => m.IdMovie);
            modelBuilder.Entity<TrailersConnMovie>().HasOne(m => m.Movie).WithMany(mtp => mtp.TrailersConnMovies).HasForeignKey(m => m.IdMovie);

            modelBuilder.Entity<PeopleConnJob>().HasOne(m => m.People).WithMany(mtp => mtp.PeopleConnJobs).HasForeignKey(m => m.IdPeople);


            modelBuilder.Entity<PeopleDirectorConnMovie>().HasOne(m => m.People).WithMany(mtp => mtp.PeopleDirectorConnMovies).HasForeignKey(m => m.IdPeople);
            modelBuilder.Entity<PeoplePerformerConnMovie>().HasOne(m => m.People).WithMany(mtp => mtp.PeoplePerformerConnMovies).HasForeignKey(m => m.IdPeople);
            modelBuilder.Entity<NationConnMovie>().HasOne(m => m.Nation).WithMany(mtp => mtp.NationConnMovies).HasForeignKey(m => m.IdNation);
            modelBuilder.Entity<GenreConnMovie>().HasOne(m => m.Genre).WithMany(mtp => mtp.GenreConnMovies).HasForeignKey(m => m.IdGenre);
            modelBuilder.Entity<PeopleConnJob>().HasOne(m => m.Job).WithMany(mtp => mtp.PeopleConnJobs).HasForeignKey(m => m.IdJob);

            modelBuilder.Entity<CollectionMovies>().HasOne(m => m.Movie).WithMany(mtp => mtp.collectionMovies).HasForeignKey(m => m.IdMovie);
            modelBuilder.Entity<CollectionMovies>().HasOne(m => m.User).WithMany(mtp => mtp.collectionMovies).HasForeignKey(m => m.IdUser);
        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
