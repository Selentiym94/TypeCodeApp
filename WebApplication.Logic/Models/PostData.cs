namespace WebApplication.Logic.Models
{
    public class PostData
    {
        public PostData(Post post, List<Comment> comments)
        {
            Post = post;
            Comments = comments;
        }
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
