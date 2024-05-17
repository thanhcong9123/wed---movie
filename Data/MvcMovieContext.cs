using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppFilm.Net.Models;

namespace AppFilm.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }
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
        }
        public DbSet<AppFilm.Net.Models.Movie> Movie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.CollectionMovies> CollectionMovies { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.People> People { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.Nation> Nation { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.Genre> Genre { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.GenreConnMovie> GenreConnMovie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.NationConnMovie> NationConnMovie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.PeoplePerformerConnMovie> PeoplePerformerConnMovies { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.PeopleDirectorConnMovie> PeopleDirectorConnMovies { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.Years> Years { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.Job> Job { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.PeopleConnJob> PeopleConnJob { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.MovieType> MovieType { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.Trailers> Trailers { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.TrailersConnMovie> TrailersConnMovie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.ItemMovie> ItemMovie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.ViewDay> ViewDay { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.ViewMonth> ViewMonth { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.ViewWeek> ViewWeek { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.LinkMovie> LinkMovie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.SeasonsConnLinkMovie> SeasonsConnLinkMovie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.SeasonsConnMovie> SeasonsConnMovie { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.Season> Season { get; set; } = default!;
        public DbSet<AppFilm.Net.Models.SeasonsConnPeople> SeasonsConnPeople { get; set; } = default!;


    }
}
