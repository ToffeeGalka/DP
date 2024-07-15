using Business.Models;

namespace Business.Validators
{
    public static class PostValidator
    {
        public static void Validate(Post post)
        {
            if (string.IsNullOrEmpty(post.PostName))
                throw new Exception("NAME POST IS NOT BE NULL OR EMPTY");
        }
    }
}
