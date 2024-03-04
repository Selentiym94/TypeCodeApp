using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Logic.Interfaces;

namespace WebApplication.Logic.Models.Requests
{
    public class GetPostRequest : ITypeCodeRequest
    {
        public GetPostRequest(int userId=0)
        {
            UserId = userId;
        }
        public int UserId { get; set; }

        public string GetUrlParams()
        {
            string result = "posts";
            if (UserId!=0)
            {
                result += $"?userId={UserId}";
            }
            return result;
        }
    }
}
