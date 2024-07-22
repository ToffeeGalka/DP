using Business.Models;

namespace Business.Validators
{
    public class PostValidator : IPostValidator
    {
        public void Validate(Post post)
        {
            if (string.IsNullOrEmpty(post.PostName))
                throw new Exception("NAME POST IS NOT BE NULL OR EMPTY");
        }
    }
}
