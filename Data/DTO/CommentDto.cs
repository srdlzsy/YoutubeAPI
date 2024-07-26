using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class CommentDto
    {
        public string Text { get; set; }
        public DateTime PublishedOn { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
