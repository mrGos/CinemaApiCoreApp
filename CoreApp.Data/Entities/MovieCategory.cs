using CoreApp.Data.Enums;
using CoreApp.Data.Interfaces;
using CoreApp.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.Data.Entities
{
    [Table("MovieCategories")]
    public class MovieCategory : DomainEntity<int>, ISeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public MovieCategory()
        {
            Movies = new List<Movie>();
        }
        public MovieCategory(string name, string description, int? parentId, int? homeOrder,
            string image, bool? homeFlag, int sortOrder, Status status, string seoPageTitle, string seoAlias,
            string seoKeywords, string seoDescription)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }


        public virtual ICollection<Movie> Movies { set; get; }
    }
}