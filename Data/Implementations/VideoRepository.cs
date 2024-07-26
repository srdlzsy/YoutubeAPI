using Core.Entities;
using Core.Interfaces;
using Data.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(MyContext context) : base(context)
        {
        }

        public IEnumerable<Video> GetPopularVideos(int topN)
        {
            return _context.Set<Video>()
                   .OrderByDescending(video => video.Likes.Count) // En çok beğenilenleri önce al
                   .Take(topN) // Belirtilen sayıda video al
                   .ToList(); // Listeye dönüştür
        }
        public IEnumerable<Video> GetAllWithDetails()
        {
            return _context.Set<Video>()
                .Include(v => v.Comments)  // Yorumları yükle
                .Include(v => v.Likes)     // Beğenileri yükle
                .Include(v => v.Category)  // Kategoriyi yükle
                .ToList();
        }

        public Video GetVideoById(int id)
        {
           var video = _context.Set<Video>().Include(v => v.Comments)
                   .Include(v => v.Likes)
                   .FirstOrDefault(v => v.VideoId == id);
            return video;
        }
    }
}
