﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
