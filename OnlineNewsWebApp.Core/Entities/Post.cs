using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using OnlineNewsWebApp.Core.Entities;

namespace OnlineNewsWebApp.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        // main content and short description for displaying
        public string ShortDescription { get; set; }
        [MaxLength]
        public string PostContent { get; set; }

        // link of a post
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        // total views of a post
        public int ViewCount { get; set; }

        // total times a post being rated
        public int RateCount { get; set; }
        // total rate points of a post
        public int TotalRate { get; set; }
        // average ratio based on RateCount and TotalRate
        // No need to create column in database
        [NotMapped]
        public decimal Rate => RateCount > 0 ? TotalRate / RateCount : 0;

        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<PostTagMap> PostTagMaps { get; set; }
        public ICollection<Comment> Comments { get; set; }
        [NotMapped]
        public string? AuthorId { get; set; }
        public User? Author { get; set; }
    }
}
