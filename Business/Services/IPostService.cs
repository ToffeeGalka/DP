using Business.Models;
using WebData.Entities;

namespace Business.Services
{
    public interface IPostService
    {
        public PostEntity[] GetAll();
        public Task<int> AddPost(Post postEntity);
        public Task EditPost(Post postEntity);
        public Task DeletePost(int idPost);
    }
}
