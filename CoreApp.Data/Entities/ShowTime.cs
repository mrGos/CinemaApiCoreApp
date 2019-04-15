using CoreApp.Data.Enums;
using CoreApp.Data.Interfaces;
using CoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreApp.Data.Entities
{
    [Table("ShowTimes")]
    public class ShowTime : DomainEntity<int>, IDateTracking, ISoftDelete, ISwitchable
    {
        public ShowTime()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
            Status = Status.NowShowing;
            IsDeleted = true;
            DateShowing = DateTime.Now;
        }
        public int MovieTheaterId { get; set; }
        public DateTime DateShowing { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string TimeShowing { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public Status Status { get; set; }
        [ForeignKey("MovieTheaterId")]
        public virtual MovieTheater MovieTheater { get; set; }
    }
}
