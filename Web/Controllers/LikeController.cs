using Business.Services;
using Core.Entities;
using Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private LikeServices _likeServices;

        public LikeController(LikeServices likeServices)
        {
            _likeServices = likeServices;
        }
        [HttpPost]
        public ActionResult Addlike(LikeDto dto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı");
            }
            var like = new Like { UserId= int.Parse(userIdClaim),VideoId=dto.PostId };
            _likeServices.Add(like);
            return Ok(like);
        }
    }
}
