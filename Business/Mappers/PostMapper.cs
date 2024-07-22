using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public class PostMapper: IPostMapper
    {
        public Post MapToModel(PostEntity entity)
        {
            return new Post
            {
                Id = entity.Id,
                PostName = entity.PostName
            };
        }
        public PostEntity MapFromModel(Post post) 
        {
            return new PostEntity
            {
                Id = post.Id,
                PostName = post.PostName
            };
        }
    }
}
