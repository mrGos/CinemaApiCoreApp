using CoreApp.Data.Enums;
using CoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using CoreApp.Data.Interfaces;

namespace CoreApp.Data.Entities
{
    [Table("Advertisetments")]
    public class Advertisement : DomainEntity<int>, ISwitchable, ISortable, IDateTracking
    {
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(20)]
        public string PositionId { get; set; }

        public Status Status { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }

        [ForeignKey("PositionId")]
        public virtual AdvertisementPosition AdvertisementPosition { get; set; }

    }
}
