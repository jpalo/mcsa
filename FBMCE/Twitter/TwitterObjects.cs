using System;
using System.Collections.Generic;
using System.Text;

namespace FBMCE
{
    public class TwitterUser
    {
        public int id { get; set; }
        public string id_str { get; set; }
        public string screen_name { get; set; }
        public string name { get; set; }
    }

    public class TwitterHashtag
    {
        public string text { get; set; }
        public List<int> indices { get; set; }
    }

    public class TwitterUrl
    {
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public List<int> indices { get; set; }
    }

    public class TwitterUserMention
    {
        public string screen_name { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string id_str { get; set; }
        public List<int> indices { get; set; }
    }

    public class TwitterEntities
    {
        public List<TwitterHashtag> hashtags { get; set; }
        public List<object> symbols { get; set; }
        public List<TwitterUrl> urls { get; set; }
        public List<TwitterUserMention> user_mentions { get; set; }
    }

    public class TwitterRootObject
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public string source { get; set; }
        public bool truncated { get; set; }
        public object in_reply_to_status_id { get; set; }
        public object in_reply_to_status_id_str { get; set; }
        public object in_reply_to_user_id { get; set; }
        public object in_reply_to_user_id_str { get; set; }
        public object in_reply_to_screen_name { get; set; }
        public TwitterUser user { get; set; }
        public object geo { get; set; }
        public object coordinates { get; set; }
        public object place { get; set; }
        public object contributors { get; set; }
        public int retweet_count { get; set; }
        public int favorite_count { get; set; }
        public TwitterEntities entities { get; set; }
        public bool favorited { get; set; }
        public bool retweeted { get; set; }
        public bool possibly_sensitive { get; set; }
        public string lang { get; set; }
    }
}
