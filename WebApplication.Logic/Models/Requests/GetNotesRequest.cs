using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Logic.Interfaces;

namespace WebApplication1.Logic.Models.Requests
{
    public class GetNotesRequest : ITypeCodeRequest
    {
        public GetNotesRequest(int userId)
        {
            UserId = userId;
        }
        public int UserId { get; set; }
        public string GetUrlParams()
        {
            string result = "todos";
            if (UserId != 0)
            {
                result += $"?userId={UserId}";
            }
            return result;
        }
    }
}
