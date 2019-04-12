using CoreApp.Data.Enums;
using CoreApp.Data.Interfaces;
using CoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.Data.Entities
{
    [Table("Movies")]
    public class Movie : DomainEntity<int>, ISwitchable, IDateTracking, ISeoMetaData
    {
        public Movie()
        {
            MovieTheaters = new List<MovieTheater>();
            MovieImages = new List<MovieImage>();

            Nation = "Mỹ";
            TimeSpan = "100 phút";
            IMDbPoints = "8";
            Rating = "C13";
            Format = "2D/Digital";
            Category = "Hành động";
            Cast = "";
            Director = "";
            Image = "";
            Video = "";
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
            ReleasedDate = DateTime.Now;
        }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(255)]
        public string Video { get; set; }

        [StringLength(255)]
        public string Director { get; set; }
        [StringLength(500)]
        public string Cast { get; set; }
        [StringLength(255)]
        public string Category { get; set; }
        [StringLength(255)]
        public string Format { get; set; }
        [StringLength(255)]
        public string Nation { get; set; }
        public DateTime ReleasedDate { get; set; }
        [StringLength(255)]
        public string Rating { get; set; }
        [StringLength(255)]
        public string TimeSpan { get; set; }
        [StringLength(20)]
        public string IMDbPoints { get; set; }


        [StringLength(1000)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }


        public string SeoPageTitle { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<MovieTheater> MovieTheaters { set; get; }
        public virtual ICollection<MovieImage> MovieImages { set; get; }
    }
}