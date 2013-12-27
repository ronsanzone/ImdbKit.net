using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImdbKit
{
    public class ImdbClient : IImdbClient
    {
        public ActorSearch testJsonConnection()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Nobody");
            var response =
                client.DownloadString(new Uri("http://www.imdb.com/xml/find?json=1&nr=1&nm=on&q=jeniffer+garner"));
            var j = JsonConvert.DeserializeObject<ActorSearch>(response);

            return j;
        }
    }

    public class ActorSearch
    {
        public List<Actor> name_approx { get; set; }
    }

    public class Actor
    {
        public string id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
