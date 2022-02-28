namespace MarkPro.Models
{

    public class WhoWatched
    {
        public WhoResponse response { get; set; }
    }

    public class WhoResponse
    {
        public string result { get; set; }
        public object message { get; set; }
        public WhoDatum[] data { get; set; }
    }

    public class WhoDatum
    {
        public string friendly_name { get; set; }
        public int user_id { get; set; }
        public string user_thumb { get; set; }
        public string username { get; set; }
        public int total_plays { get; set; }
        public int total_time { get; set; }
    }

}
