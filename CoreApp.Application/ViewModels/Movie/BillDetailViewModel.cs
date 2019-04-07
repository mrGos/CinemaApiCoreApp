using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CoreApp.Application.ViewModels.System;
using CoreApp.Data.Enums;

namespace CoreApp.Application.ViewModels.Movie
{
    public class BillDetailViewModel
    {
        public int Id { get; set; }

        public int BillId { set; get; }

        public int ShowTimeId { set; get; }

        public int SeatId { set; get; }
        public decimal Price { set; get; }

        public BillViewModel Bill { set; get; }

        public ShowTimeViewModel ShowTime { set; get; }
        public SeatModel Seat { set; get; }
    }
}
