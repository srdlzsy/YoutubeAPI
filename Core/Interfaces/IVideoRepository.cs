using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IVideoRepository : IRepository<Video>
    {
        IEnumerable<Video> GetPopularVideos(int topN);
        IEnumerable<Video> GetAllWithDetails();
        Video GetVideoById(int id);
       


    }
}
