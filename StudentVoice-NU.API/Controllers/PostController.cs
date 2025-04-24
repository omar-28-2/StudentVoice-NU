using Microsoft.AspNetCore.Mvc;
using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.Entities;
using StudentVoiceNU.Infrastructure.Services;
using StudentVoiceNU.Application.Services;
using StudentVoiceNU.Domain.DTOs;

namespace StudentVoiceNU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostService _postService;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _postService = new PostService(postRepository);
        }

    [HttpGet("user/{userId}/posts")]
    public async Task<IActionResult> GetPost(
    int userId,
    [FromQuery] int postNumber = 1,
    [FromQuery] int postSize = 10)
    {
        var posts = await _postService.GetPostsByUser(userId, postNumber, postSize);
        return Ok(posts);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postService.GetPostById(id);
        if (post == null) return NotFound();
        return Ok(post);
    }
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] CreatePostDto createPostDto)
    {
            var createdPost = await _postService.CreatePost(createPostDto);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] CreatePostDto updatePostDto)
    {
        var isUpdated = await _postService.UpdatePost(id, updatePostDto);
        if (!isUpdated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var isDeleted = await _postService.DeletePost(id);
        if (!isDeleted) return NotFound();
        return NoContent();
    }
    }
}