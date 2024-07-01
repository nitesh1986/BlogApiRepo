using Microsoft.AspNetCore.Mvc;
using BlogApi.Models;
using BlogApi.Services;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly BlogPostService _repository;

        public BlogPostsController(BlogPostService repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogPost>>> GetBlogPosts()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
            var blogPost = await _repository.GetByIdAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return blogPost;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlogPost(BlogPost blogPost)
        {
            await _repository.AddAsync(blogPost);
            return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.Id }, blogPost);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlogPost(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return BadRequest();
            }

            var existingBlogPost = await _repository.GetByIdAsync(id);
            if (existingBlogPost == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(blogPost);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlogPost(int id)
        {
            var existingBlogPost = await _repository.GetByIdAsync(id);
            if (existingBlogPost == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }

}
