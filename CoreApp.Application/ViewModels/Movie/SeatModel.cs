using CoreApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Application.ViewModels.Movie
{
    public class SeatModel
    {
        public int Id { get; set; }
        public string Range { get; set; }
        public int Position { get; set; }
        public SeatType Type { get; set; }
    }
}
