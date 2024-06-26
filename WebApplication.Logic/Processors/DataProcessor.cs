﻿using WebApplication1.Logic.Interfaces;
using WebApplication1.Logic.Models;

namespace WebApplication1.Logic.Processors
{
    public class DataProcessor
    {
        private ITypecodeClient _client;
        public DataProcessor(ITypecodeClient client)
        {
            _client = client;
        }

        public async Task<TypeCodeData> Get(string userName)
        {
            TypeCodeData typeCodeData = new TypeCodeData();
            typeCodeData.User = (await _client.GetUser(userName))[0];
            typeCodeData.Notes = await _client.GetNotes(typeCodeData.User.Id);
            typeCodeData.AlbumDats = await GetAlbumData(typeCodeData.User.Id);
            typeCodeData.PostDats = await GetPostData(typeCodeData.User.Id);
            return typeCodeData;

        }

        private async Task<List<AlbumData>> GetAlbumData(int userId)
        {
            List<AlbumData> result = new List<AlbumData>();
            List<Album> albums = await _client.GetAlbums(userId);
            foreach (Album album in albums)
            {
                List<Photo> photos = await _client.GetPhotos(album.Id);
                AlbumData data = new AlbumData(album, photos);
                result.Add(data);
            }
            return result;
        }
        private async Task<List<PostData>> GetPostData(int userId)
        {
            List<PostData> result = new List<PostData>();
            List<Post> posts = await _client.GetPosts(userId);
            foreach (Post post in posts)
            {
                List<Comment> comments = await _client.GetComments(post.Id);
                PostData data = new PostData(post, comments);
                result.Add(data);
            }
            return result;
        }
    }
}
