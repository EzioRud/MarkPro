namespace MarkPro.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RequestCount { get; set; }
        public string DisplayImage { get; set; }


        public int TotalPlays { get; set; }
        public int TotalTime { get; set; }
        public string RatingKey { get; set; }

        public int CompletionStatus { get; set; }
     
    }
}
