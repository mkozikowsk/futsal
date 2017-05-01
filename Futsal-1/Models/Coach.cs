using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class Coach
    {
        public int Id { get; set; }

        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Trener")]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }  
        }

        public virtual List<Team> Teams { get; set; }
    }
}