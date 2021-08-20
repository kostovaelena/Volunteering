using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Volunteering.Models
{
    public class Kategorija
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        public string Slika { get; set; }


    }
}