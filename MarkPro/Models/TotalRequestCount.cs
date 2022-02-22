namespace MarkPro.Models
{

    public class TotalRequestCount
    {
        public int PendingRequests { get; set; }
        public int AvailableRequests { get; set; }
        public int ProcessingRequests { get; set; }
        public int ApprovedRequests { get; set; }
    }

}
