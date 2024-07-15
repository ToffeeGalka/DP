using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using WebData.Entities;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController(IPostService postService) : ControllerBase
    {
        [HttpGet("GetPostAll")]
        public PostEntity[] GetAll() => postService.GetAll();

        [HttpPost("AddPost")]
        public async Task AddPost(Post postEntity) => await postService.AddPost(postEntity);

        [HttpPut("EditPost")]
        public async Task EditPost(Post post) => await postService.EditPost(post);

        [HttpDelete("DeletePost")]
        public async Task DeletePost(int idPost) => await postService.DeletePost(idPost);
    }
}
