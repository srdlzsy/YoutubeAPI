using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Entities
{
    public class Video
    {
        public int VideoId { get; set; }
        public string ?Title { get; set; }
        public string ?Description { get; set; }
        public string ?Url { get; set; }
        public DateTime PublishedOn { get; set; }
        public int UserId { get; set; }
        public AppUser ?User { get; set; }
        public int CategoryId { get; set; } // Category ile ilişki için
        public Category ?Category { get; set; } // Category ile ilişki için
        public ICollection<Comment> ?Comments { get; set; }
        public ICollection<Like> ?Likes { get; set; }
        public int LikesCount { get { return Likes?.Count ?? 0; } }
        public int CommentsCount { get { return Comments?.Count ?? 0; } }
    }

}
