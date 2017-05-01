using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Futsal_1.Models
{
    /// <summary>
    /// Class PlayersModel
    /// </summary>
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}