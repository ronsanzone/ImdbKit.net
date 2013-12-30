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
            var processor =
                new ActorJsonResponseProcessor("http://www.imdb.com/xml/find?json=1&nr=1&nm=on&q=jeniffer+garner");
            processor.ProcessResponse();
            return processor.GetHolder() as ActorSearch;
        }
    }

    public class ActorJsonResponseProcessor
    {
        private ActorSearch _actorSearchHolder;
        private Uri _path;

        public ActorJsonResponseProcessor(string path)
        {
            _path = new Uri(path);
        }

        protected string retrieveResponse(Uri path)
        {
            var retriever = new JsonResponseRetriever(path);
            return retriever.RetrieveResponse();
        }
        public void ProcessResponse()
        {
            var response = retrieveResponse(_path);
            _actorSearchHolder = JsonConvert.DeserializeObject<ActorSearch>(response);
        }
        public IJsonHolder GetHolder()
        {
            return _actorSearchHolder;
        }

    }

    public class JsonResponseRetriever
    {
        private readonly Uri _path;

        public JsonResponseRetriever(Uri path)
        {
            _path = path;
        }

        public string RetrieveResponse()
        {
            var client = new WebClient();
            client.Headers.Add("User-Agent", "Nobody");
            return client.DownloadString(_path);
        }
    }
    public interface IJsonHolder
    {
        
    }
    public class ActorSearch : IJsonHolder
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
