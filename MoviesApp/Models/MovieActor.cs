using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class MovieActor
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        [ForeignKey(nameof(Actor))]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
