using CoreApp.Data.Enums;
using CoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreApp.Data.Entities
{
    [Table("Seats")]
    public class Seat : DomainEntity<int>
    {
        [Column(TypeName = "varchar(20)")]
        public string Range { get; set; }
        public int Position { get; set; }
        public SeatType Type { get; set; }
    }
}
