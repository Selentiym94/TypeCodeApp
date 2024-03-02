using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication.Logic.Interfaces;
using WebApplication.Logic.Models;

namespace WebApplication.Logic.Processors
{
    public class TypecodeClient: ITypecodeClient
    {
        private readonly string _baseUrl;

        public TypecodeClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public List<Album> GetAlbums(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments(int postId)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetNotes(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Photo> GetPhotos(int albumId)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPosts(int userId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUser(string name)
        {
            throw new NotImplementedException();
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
