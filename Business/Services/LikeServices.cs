using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LikeServices : BaseService<Like>
    {
        public LikeServices(IRepository<Like> repository) : base(repository)
        {
        }
    }
}
