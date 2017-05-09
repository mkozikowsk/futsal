using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class Arbiter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public virtual List<Match> Matches { get; set; }
    }
}