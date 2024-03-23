using WebApplication1.Logic.Interfaces;

namespace WebApplication1.Logic.Models.Requests
{
    public class GetUserRequest : ITypeCodeRequest
    {
        public GetUserRequest(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public string GetUrlParams()
        {
            string result = "users";
            if (!string.IsNullOrEmpty(Name))
            {
                result += $"?name={Name}";
            }
            return result;
        }
    }
}
