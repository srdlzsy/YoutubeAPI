using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string ?Text { get; set; }
        public DateTime PublishedOn { get; set; }
        public int UserId { get; set; }
        public AppUser ?User { get; set; }
        public int VideoId { get; set; }
        public Video ?Video { get; set; }
    }
}
