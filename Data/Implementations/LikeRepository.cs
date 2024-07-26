using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class LikeRepository : Repository<Like>, ILikeRepository
    {
        public LikeRepository(MyContext context) : base(context)
        {
        }
    }
}
