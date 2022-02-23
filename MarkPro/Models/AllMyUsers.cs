namespace MarkPro.Models
{

    public class MyUsers
    {
        public Pageinfo pageInfo { get; set; }
        public MyResult[] results { get; set; }
    }

    public class MyPageinfo
    {
        public int pages { get; set; }
        public int pageSize { get; set; }
        public int results { get; set; }
        public int page { get; set; }
    }

    public class MyResult
    {
        public int permissions { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string plexUsername { get; set; }
        public object username { get; set; }
        public object recoveryLinkExpirationDate { get; set; }
        public int userType { get; set; }
        public string avatar { get; set; }
        public object movieQuotaLimit { get; set; }
        public object movieQuotaDays { get; set; }
        public object tvQuotaLimit { get; set; }
        public object tvQuotaDays { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int requestCount { get; set; }
        public string displayName { get; set; }
    }

}
