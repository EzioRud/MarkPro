namespace MarkPro.Models
{
    public class ParentRequests
    {

        public TotalRequests[] TotalRequests;
    }
    public class TotalRequests
    {
        public int pending { get; set; }
        public int approved { get; set; }
        public int processing { get; set; }
        public int available { get; set; }
    }
}
