using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Logic.Interfaces;

namespace WebApplication1.Logic.Models.Requests
{
    public class GetCommentRequest : ITypeCodeRequest
    {
        public int PostId { get; set; }

        public GetCommentRequest(int postId)
        {
            PostId = postId;
        }
        public string GetUrlParams()
        {
            string result = "comments";
            if (PostId > 0)
            {
                result += $"postId={PostId}";
            }
            return result;

        }
    }
}
