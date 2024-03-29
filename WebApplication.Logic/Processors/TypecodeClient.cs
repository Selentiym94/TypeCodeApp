﻿using System.Text.Json;
using WebApplication1.Logic.Interfaces;
using WebApplication1.Logic.Models;
using WebApplication1.Logic.Models.Requests;

namespace WebApplication1.Logic.Processors
{
    public class TypecodeClient: ITypecodeClient
    {
        private readonly string _baseUrl;

        public TypecodeClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<List<Album>> GetAlbums(int userId = 0)
        {
            ITypeCodeRequest albumsRequest = new  GetAlbumRequest(userId);
            return await GetData<Album>(albumsRequest); 
        }

        public async Task<List<Comment>> GetComments(int postId)
        {
            ITypeCodeRequest commentRequest =new GetCommentRequest(postId);
            return await GetData<Comment>(commentRequest);
        }

        public async Task<List<Note>> GetNotes(int userId = 0)
        {
            ITypeCodeRequest todosRequest = new GetNotesRequest(userId);
            return await GetData<Note>(todosRequest);
        }

        public async Task<List<Photo>> GetPhotos(int albumId = 0)
        {
            ITypeCodeRequest photoRequest = new GetPhotoRequest(albumId);
            return await GetData<Photo>(photoRequest);
            
        }

        public async Task<List<Post>> GetPosts(int userId = 0)
        {
            ITypeCodeRequest postRequest = new GetPostRequest(userId);
            return await GetData<Post>(postRequest);
           
        }

        public async Task<List<User>> GetUser(string name)
        {
            ITypeCodeRequest userRequest = new GetUserRequest(name);
            return await GetData<User>(userRequest);
        }

        private async Task<List<TData>> GetData<TData>(ITypeCodeRequest request)
        {
            using (HttpClient client = new HttpClient())
            {
                string urlData = request.GetUrlParams();
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri($"{_baseUrl}/{urlData}");

                HttpResponseMessage response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<TData>>(content) ?? new List<TData>();
                }
                return new List<TData>();
            }

        }
    }
}
