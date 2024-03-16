﻿using WebApplication.Logic.Models;

namespace WebApplication.Logic.Interfaces
{
    public  interface ITypecodeClient
    {
        Task<List<User>> GetUser(string name);
        Task<List<Album>> GetAlbums(int userId);
        Task<List<Note>> GetNotes(int userId);
        Task<List<Post>> GetPosts(int userId);
        Task<List<Comment>> GetComments(int postId);
        Task<List<Photo>> GetPhotos(int albumId);
    }
}
