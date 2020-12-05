using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
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
