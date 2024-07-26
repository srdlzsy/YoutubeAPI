using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Like
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public int VideoId { get; set; }
        public Video ?Video { get; set; }
    }
}
