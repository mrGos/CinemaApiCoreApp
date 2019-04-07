using CoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Application.ViewModels.Movie
{
    public class ShowTimeViewModel
    {
        public int Id { get; set; }
        public int MovieTheaterId { get; set; }
        public DateTime DateTimeShowing { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public Status Status { get; set; }

        public virtual MovieTheaterViewModel MovieTheaterViewModel { get; set; }
    }
}
