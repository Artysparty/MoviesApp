using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public float Weight { get; set; }
        public float Growth { get; set; }
    }
}
