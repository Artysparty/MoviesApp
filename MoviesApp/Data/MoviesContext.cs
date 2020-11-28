using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieActor>(e => e.HasKey(t => new { t.ActorId, t.MovieId }));
            base.OnModelCreating(builder);
        }
    }
}