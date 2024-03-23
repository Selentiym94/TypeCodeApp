using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Logic.Interfaces;

namespace WebApplication1.Logic.Models.Requests
{
    public class GetPhotoRequest:ITypeCodeRequest
    {
        
      
            public GetPhotoRequest(int albumId = 0)
            {
                AlbumId = albumId;
            }
            public int AlbumId { get; set; }

            public string GetUrlParams()
            {
                string result = "photos";
                if (AlbumId != 0)
                {
                    result += $"?albumId={AlbumId}";
                }
                return result;
            }
       
    }
}
