using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    /// <summary>
    /// Class TeamsModel
    /// </summary>
    public class Team
    {
        public int Id { get; set; }

        [Display(Name = "Drużyna")]
        public string Name { get; set; }
        [Display(Name = "Trener")]
        public int CoachId { get; set; }


        public virtual Coach Coach { get; set; }
        public virtual List<Player> Players { get; set; }
        public virtual  List<SeasonLeauge> SeasonLeauges { get; set; }
        

    }
}