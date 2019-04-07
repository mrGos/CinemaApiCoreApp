using CoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreApp.Data.Entities
{
    [Table("MovieTags")]
    public class MovieTag : DomainEntity<int>
    {
        public int MovieId { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string TagId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { set; get; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { set; get; }
    }
}
