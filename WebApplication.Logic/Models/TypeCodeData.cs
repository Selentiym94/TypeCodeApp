namespace WebApplication.Logic.Models
{
    public class TypeCodeData
    {
        public User User { get; set; }
        public List<Note> Notes { get; set; }
        public List<AlbumData> AlbumDats { get; set; }
        public List<PostData> PostDats { get; set; }
    }
}
