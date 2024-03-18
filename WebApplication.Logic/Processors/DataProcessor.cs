using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Logic.Interfaces;
using WebApplication.Logic.Models;

namespace WebApplication.Logic.Processors
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

            User user = (await _client.GetUser(userName))[0];
            List<Note> notes = await _client.GetNotes(user.Id);

        }
        private async Task<List<AlbumData>> GetAlbumData(int userId)
        {
            List<AlbumData> result = new List<AlbumData>();
            List<Album> albums = await _client.GetAlbums(userId);
            foreach (Album album in albums)
            {
                List<Photo> photos = await _client.GetPhotos(userId);
                AlbumData data = new AlbumData(album, photos);
                result.Add(data);
            }
            return result;
        }
    }
}
