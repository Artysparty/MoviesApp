using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<MovieActor>();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public float Weight { get; set; }
        public float Growth { get; set; }

        public virtual ICollection<MovieActor> Movies { get; set; }

    }
}
