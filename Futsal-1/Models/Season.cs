using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    public class Season
    {
        public int Id { get; set; }
        [Display(Name = "Data rozpoczęcia")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Data zakończenia")]
        public DateTime DateTo { get; set; }

        public virtual List<SeasonLeauge> SeasonLeauges { get; set; }
    }
}