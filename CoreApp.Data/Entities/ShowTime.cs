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
        public int MovieTheaterId { get; set; }
        public DateTime DateTimeShowing { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public Status Status { get; set; }
        [ForeignKey("MovieTheaterId")]
        public virtual MovieTheater MovieTheater { get; set; }
    }
}
