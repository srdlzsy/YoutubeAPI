using Business.Services;
using Core.Entities;
using Data.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentServices _commentServices;

        public CommentController(CommentServices commentServices)
        {
            _commentServices = commentServices;
        }
        [HttpPost]
        public ActionResult AddComment(CommentDto dto)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("Kullanıcı kimliği bulunamadı");
            }
            var comment =new Comment {Text=dto.Text ,UserId=int.Parse(userIdClaim),VideoId=dto.PostId};
          _commentServices.Add(comment);
            return Ok(comment);
        }
    }
}