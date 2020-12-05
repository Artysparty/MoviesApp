using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [OldActors(1920)]
        public DateTime Birthday { get; set; }
        [Range(0, 350)]
        public float Weight { get; set; }
        [Range(0, 250)]
        public float Growth { get; set; }
    }
}
