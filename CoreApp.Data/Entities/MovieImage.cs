using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoreApp.Infrastructure.SharedKernel;

namespace CoreApp.Data.Entities
{
    [Table("MovieImages")]
    public class MovieImage : DomainEntity<int>
    {
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [StringLength(250)]
        public string Path { get; set; }

        [StringLength(250)]
        public string Caption { get; set; }
    }
}
