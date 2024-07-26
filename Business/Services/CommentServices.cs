using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CommentServices(IRepository<Comment> repository) : BaseService<Comment>(repository)
    {
    }
}
