using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class VideoDto
    {

        public int VideoId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public DateTime PublishedOn { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public int CategoryId { get; set; } // Category ile ilişki için
        public Category? Category { get; set; } // Category ile ilişki için
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>(); // Varsayılan boş liste
        public List<LikeDto> Likes { get; set; } = new List<LikeDto>();
        public int LikesCount { get { return Likes?.Count ?? 0; } }
        public int CommentsCount { get { return Comments?.Count ?? 0; } }


    }
}
