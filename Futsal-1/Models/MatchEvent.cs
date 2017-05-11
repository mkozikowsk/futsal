using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime EventTime { get; set; }

        public int EventTypeId { get; set; }
        public int? PlayerId { get; set; }
        public int MatchId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Match Match { get; set; }
        public virtual EventType EventType { get; set; }
    }
}