using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Wzrost")]
        public int Height { get; set; }

        [Display(Name = "Waga")]
        public int Weight { get; set; }

        [Display(Name = "Drużyna")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }

    }
}