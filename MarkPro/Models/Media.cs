namespace MarkPro.Models
{
    public class Media
    {
        public int TotalRequests { get; set; }
        public string MediaName { get; set; }
        public string Tv { get; set; }
        public bool Pending { get; set; }
        public bool Approved { get; set; }
        public bool Declined { get; set; }
        public bool Processing { get; set; }
        public bool Available { get; set; }

    }
}
