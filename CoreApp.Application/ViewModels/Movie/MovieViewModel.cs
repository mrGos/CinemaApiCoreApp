using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CoreApp.Data.Enums;

namespace CoreApp.Application.ViewModels.Movie
{
    public class MovieViewModel
    {
        public int Id { get; set; }

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
        public string Rating { get; set; }
        [StringLength(255)]
        public string TimeSpan { get; set; }

        public decimal IMDbPoints { get; set; }


        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        public string SeoPageTitle { set; get; }

        [StringLength(255)]
        public string SeoAlias { set; get; }

        [StringLength(255)]
        public string SeoKeywords { set; get; }

        [StringLength(255)]
        public string SeoDescription { set; get; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public Status Status { set; get; }
    }
}
