using WebApplication.Logic.Models;

namespace WebApplication.Logic.Interfaces
{
    public  interface ITypecodeClient
    {
        List<User> GetUser(string name);
        List<Album> GetAlbums(int userId);
        List<Note> GetNotes(int userId);
        List<Post> GetPosts(int userId);
        List<Comment> GetComments(int postId);
        List<Photo> GetPhotos(int albumId);
    }
}
