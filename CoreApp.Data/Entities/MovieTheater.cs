using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreApp.Data.Entities;
using CoreApp.Infrastructure.SharedKernel;

namespace CoreApp.Data.Entities
{
    [Table("MovieTheaters")]
    public class MovieTheater : DomainEntity<int>
    {
        public MovieTheater()
        {
            ShowTimes = new List<ShowTime>();
        }
        public int MovieId { set; get; }

        public int TheaterId { set; get; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { set; get; }

        [ForeignKey("TheaterId")]
        public virtual Theater Theater { set; get; }

        public virtual ICollection<ShowTime> ShowTimes { set; get; }
    }
}
