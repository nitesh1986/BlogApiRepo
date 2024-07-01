using System.Collections.Generic;
using System.IO;
using System.Linq;
//using Newtonsoft.Json;
using BlogApi.Models;
using System.Xml;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogApi.Services
{
    public class BlogPostService
    {
        private readonly string _filePath;

        public BlogPostService(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<BlogPost>();
            }

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<BlogPost>>(json) ?? new List<BlogPost>();
        }

        public async Task<BlogPost> GetByIdAsync(int id)
        {
            var blogPosts = await GetAllAsync();
            return blogPosts.FirstOrDefault(bp => bp.Id == id);
        }

        public async Task AddAsync(BlogPost blogPost)
        {
            var blogPosts = await GetAllAsync();
            blogPost.Id = blogPosts.Any() ? blogPosts.Max(bp => bp.Id) + 1 : 1;
            blogPosts.Add(blogPost);
            await SaveAllAsync(blogPosts);
        }

        public async Task UpdateAsync(BlogPost blogPost)
        {
            var blogPosts = await GetAllAsync();
            var index = blogPosts.FindIndex(bp => bp.Id == blogPost.Id);
            if (index != -1)
            {
                blogPosts[index] = blogPost;
                await SaveAllAsync(blogPosts);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var blogPosts = await GetAllAsync();
            var blogPost = blogPosts.FirstOrDefault(bp => bp.Id == id);
            if (blogPost != null)
            {
                blogPosts.Remove(blogPost);
                await SaveAllAsync(blogPosts);
            }
        }

        private async Task SaveAllAsync(List<BlogPost> blogPosts)
        {
            var json = JsonSerializer.Serialize(blogPosts);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}

