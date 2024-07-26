
using Core.Entities;
using Core.Interfaces;
using Data.DTO;
using Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class VideoServices : BaseService<Video>
    {
        private readonly IVideoRepository _videoRepository;
     
   

        public VideoServices(IVideoRepository repository) : base(repository)
        {
            _videoRepository = repository;
            
        }

        public IEnumerable<Video> GetAllWithDetails()
        {

            return _videoRepository.GetAllWithDetails();
            
        }
        public Video GetAllWithDetailsbyıd( int id)
        {
            return _videoRepository.GetVideoById(id);
        }
        public IEnumerable<Video> Getpopular(int t)
        {

            return _videoRepository.GetPopularVideos(t);
        }

    }
}