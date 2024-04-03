using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineNewsWebApp.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int Count { get; set; }
        public ICollection<PostTagMap> PostTagMaps { get; set; }
    }
}
