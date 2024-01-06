namespace HarmonyHub.Data.Models
{
    public class DashboardModel
    {
        public List<SongModel> Trends { get; set; } = new List<SongModel>();
        public List<SongModel> NewSongs { get; set; } = new List<SongModel>();
        public List<SongModel> TopSongs { get; set; } = new List<SongModel>();
    }
}
