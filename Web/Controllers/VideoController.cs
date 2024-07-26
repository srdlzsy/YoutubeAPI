using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Data.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Core.Entities;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly VideoServices _videoService;
        private readonly IHttpContextAccessor _contextAccessor;


        public VideoController(VideoServices videoService, IHttpContextAccessor contextAccessor)
        {
            _videoService = videoService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public ActionResult GetVideos()
        {
            var all = _videoService.GetAllWithDetails().Select(video => new VideoDto
            {
                Title = video.Title,
                Description = video.Description,
                Url = video.Url,
                PublishedOn = video.PublishedOn,
                UserId = video.UserId,
                Comments = video.Comments?.Select(comment => new CommentDto
                {
                    PostId = comment.VideoId,
                    UserId = comment.UserId,
                    Text = comment.Text,
                    PublishedOn = comment.PublishedOn,
                    
                }).ToList() ?? new List<CommentDto>(),
                Likes = video.Likes?.Select(like => new LikeDto
                {
                    PostId = like.VideoId,
                    UserId = like.UserId,
                }).ToList() ?? new List<LikeDto>()
            }).ToList();

            return Ok(all);
        }

        [HttpGet("{id}")]
        public ActionResult GetVideoById(int id)
        {
            var video = _videoService.GetAllWithDetailsbyıd(id);

            if (video == null)
            {
                return NotFound();
            }

            var videoDto = new VideoDto
            {
                VideoId = video.VideoId,
                Title = video.Title,
                Description = video.Description,
                Url = video.Url,
                PublishedOn = video.PublishedOn,
                UserId = video.UserId,
                Comments = video.Comments?.Select(comment => new CommentDto
                {
                    PostId = comment.VideoId,
                    UserId = comment.UserId,
                    Text = comment.Text,
                    PublishedOn = comment.PublishedOn,
                }).ToList() ?? new List<CommentDto>(),
                Likes = video.Likes?.Select(like => new LikeDto
                {
                    PostId = like.VideoId,
                    UserId = like.UserId,
                }).ToList() ?? new List<LikeDto>()
            };

            return Ok(videoDto);
        }

       
        [HttpPost]
        public ActionResult AddVideo(AddVideoDto videoDto)
        {
            var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı");
            }

            if (!int.TryParse(userId, out var userIdInt))
            {
                throw new UnauthorizedAccessException("Geçersiz kullanıcı kimliği");
            }

            var video = new Video
            {
                VideoId = videoDto.VideoId,
                CategoryId = videoDto.CategoryId,
                Title = videoDto.Title,
                Description = videoDto.Description,
                Url = videoDto.Url,
                PublishedOn = videoDto.PublishedOn,
                UserId = int.Parse(userId)
            };

            _videoService.Add(video);
            return CreatedAtAction(nameof(GetVideoById), new { id = video.VideoId }, video);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult UpdateVideo(int id, [FromBody] AddVideoDto dto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Geçersiz kullanıcı kimliği.");
            }

          

            var existingVideo = _videoService.GetById(id);
            if (existingVideo == null)
            {
                return NotFound("Video bulunamadı.");
            }

            if (existingVideo.UserId != userId)
            {
                return Forbid("Yalnızca kendi videolarınızı güncelleyebilirsiniz.");
            }

            existingVideo.Title = dto.Title;
            existingVideo.Description = dto.Description;
            existingVideo.Url = dto.Url;
            existingVideo.PublishedOn = dto.PublishedOn;
            existingVideo.CategoryId = dto.CategoryId;

            _videoService.Update(existingVideo);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult DeleteVideo(int id)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı");
            }

            if (!int.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Geçersiz kullanıcı kimliği.");
            }

            var existingVideo = _videoService.GetById(id);
            if (existingVideo == null)
            {
                return NotFound("Video bulunamadı.");
            }

            if (existingVideo.UserId != userId)
            {
                return Forbid("Yalnızca kendi videolarınızı silebilirsiniz.");
            }

            _videoService.Delete(id);
            return NoContent();
        }

        [HttpGet("pop")]
        public ActionResult popularvideo(int t)
        {
            var pop = _videoService.Getpopular(t);
            return Ok(pop);
        }
    }
}
