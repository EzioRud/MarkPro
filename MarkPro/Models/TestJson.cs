namespace MarkPro.Models
{

    public class TestRoot
    {
        public TestResponse response { get; set; }
    }

    public class TestResponse
    {
        public string result { get; set; }
        public object message { get; set; }
        public TestDatum[] data { get; set; }
    }

    public class TestDatum
    {
        public string friendly_name { get; set; }
        public int user_id { get; set; }
        public string user_thumb { get; set; }
        public string username { get; set; }
        public int total_plays { get; set; }
        public int total_time { get; set; }
    }

}
