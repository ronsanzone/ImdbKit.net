using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbKit
{
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
