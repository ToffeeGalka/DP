using Microsoft.EntityFrameworkCore;
using Business.Models;
using WebData.Entities;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business.Services
{
    public class PostService(AppDbContext dbContext, IPostMapper postMapper) : IPostService
    {
        public PostEntity[] GetAll()
        {
            var post = dbContext.Posts.ToArray();
            return post;
        }
        public async Task<int> AddPost(Post post)
        {
            PostValidator.Validate(post);
            var entity = postMapper.MapFromModel(post);
            dbContext.Posts.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task EditPost(Post post)
        {
            var oldEditPost = await dbContext.Posts.FirstOrDefaultAsync(p => p.Id == post.Id);
            PostValidator.Validate(post);
            var newValues = postMapper.MapFromModel(post);
            dbContext.Entry(oldEditPost).CurrentValues.SetValues(newValues);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeletePost(int idPost)
        {
            var postId = await dbContext.Posts.FirstOrDefaultAsync(p => p.Id == idPost);
            if (postId == null)
                return;
            dbContext.Remove(postId);
            await dbContext.SaveChangesAsync();
        }
    }
}
