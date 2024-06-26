﻿using OnlineNewsWebApp.Core.Entities;
using OnlineNewsWebApp.Core.ViewModels.Category;
using OnlineNewsWebApp.Core.ViewModels.Comment;
using OnlineNewsWebApp.Core.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNewsWebApp.Core.ViewModels.Post
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public DateTime PostedOn { get; set; }
        public string ShortDescription { get; set; }
        [MaxLength]
        public string PostContent { get; set; }
        public decimal Rate { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public CategoryViewModel Category { get; set; }
        public string AuthorName { get; set; }

    }
}
