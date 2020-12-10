using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Filters;

namespace MoviesApp.Services.DTO
{
    public class ActorDto
    {
        public int? Id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "First name length can't be less than 4.")]
        [StringLength(32, ErrorMessage = "First name length can't be more than 32.")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Last name length can't be less than 4.")]
        [StringLength(32, ErrorMessage = "Last name length can't be more than 32.")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [OldActors(1920)]
        [YoungActors(2016)]
        public DateTime Birthday { get; set; }
        [Range(0, 350)]
        public float Weight { get; set; }
        [Range(0, 250)]
        public float Growth { get; set; }
    }
}
