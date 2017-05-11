using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<MatchEvent> MatchEvents { get; set; }
    }
}