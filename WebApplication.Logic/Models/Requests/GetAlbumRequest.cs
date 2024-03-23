using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Logic.Interfaces;

namespace WebApplication1.Logic.Models.Requests
{
    public class GetAlbumRequest : ITypeCodeRequest
    {
        public int UserId { get; set; }
        public GetAlbumRequest(int userId)
        {
            UserId = userId;
        }

        public string GetUrlParams()
        {
            string result = "album";
            if (UserId != 0)
            {
                result += $"?userId={UserId}";
            }
            return result;
        }
    }
}
