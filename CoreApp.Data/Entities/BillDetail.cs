using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreApp.Data.Entities;
using CoreApp.Infrastructure.SharedKernel;

namespace CoreApp.Data.Entities
{
    [Table("BillDetails")]
    public class BillDetail : DomainEntity<int>
    {
        public BillDetail() { }

        public BillDetail(int id, int billId, int showtimeId, int seatId, decimal price)
        {
            Id = id;
            BillId = billId;
            ShowTimeId = showtimeId;
            SeatId = seatId;
            Price = price;
        }

        public BillDetail(int billId, int showtimeId, int seatId, decimal price)
        {
            BillId = billId;
            ShowTimeId = showtimeId;
            SeatId = seatId;
            Price = price;
        }
        public int BillId { set; get; }

        public int ShowTimeId { set; get; }

        public int SeatId { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("BillId")]
        public virtual Bill Bill { set; get; }
        [ForeignKey("SeatId")]
        public virtual Seat Seat { set; get; }

        [ForeignKey("ShowTimeId")]
        public virtual ShowTime ShowTime { set; get; }

    }
}
