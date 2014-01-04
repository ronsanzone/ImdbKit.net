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

    public abstract class JsonResponseProcessor
    {
        protected IJsonHolder _searchHolder;
        protected Uri _path;

        protected JsonResponseProcessor()
        {
            
        }
        protected JsonResponseProcessor(string path)
        {
            _path = new Uri(path);
        }
        protected string RetrieveResponse(Uri path)
        {
            var retriever = new JsonResponseRetriever(path);
            return retriever.RetrieveResponse();
        }
        public void ProcessResponse()
        {
            var response = RetrieveResponse(_path);
            PopulateHolder(response);
        }

        protected abstract void PopulateHolder(string response);
    }

    public class ActorJsonResponseProcessor : JsonResponseProcessor
    {
        protected override void PopulateHolder(string response)
        {
            _searchHolder = JsonConvert.DeserializeObject<ActorSearch>(response);
        }

        protected ActorSearch GetHolder()
        {
            return _searchHolder as ActorSearch;
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


}
