namespace MarkPro.Models
{
    public class AllUsersWhoWatched
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int TotalPlays { get; set; }
        public int TotalTime { get; set; }
        public string RatingKey { get; set; }
    }
}
