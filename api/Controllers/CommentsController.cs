using System.Threading.Tasks;
using api.interfaces;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IcommentRepository _commentRepository;

        public CommentsController(IcommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();
            
            var commentDtos = comments.Select(c => c.ToCommentDto()).ToList();
            return Ok(commentDtos);
        }
    }
}
