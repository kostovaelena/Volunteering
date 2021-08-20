using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Volunteering.Models
{
    public class Organizacija
    {
        [Key]
        [Required]
        public int Id { set; get; }
        [Required]
        public string Ime { set; get; }
        [Required]
        public string Opis { set; get; }
        [Required]
        public string Slika { set; get; }
        public Doniraj doniraj { set; get; }

        public Organizacija()
        {
            doniraj = new Doniraj();
        }



    }
}