using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public interface IPostMapper
    {
        Post MapToModel(PostEntity entity);
        PostEntity MapFromModel(Post post);
    }
}
