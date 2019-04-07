using CoreApp.Application.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Application.ViewModels.Movie
{
    public class MovieImageViewModel
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public MovieViewModel Movie { get; set; }

        public string Path { get; set; }

        public string Caption { get; set; }
    }
}
