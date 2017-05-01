using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Team> Teams { get; set; }
    }
}