namespace MarkPro.Models
{
    public class Request
    {
        public string MediaName { get; set; }
        public string RequestedBy { get; set; }
        public int RequestCount { get; set; }
        public string MediaType { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string DateRequested { get; set; }
        public string Avatar { get; set; }
    }
}
