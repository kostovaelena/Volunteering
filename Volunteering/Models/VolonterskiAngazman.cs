using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Volunteering.Models
{
    public class VolonterskiAngazman
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Наслов на акцијата")]
        public string Naslov { get; set; }
        [Required]
        [DisplayName("Локација")]
        public string Mesto { get; set; }
        [Required]
        [DisplayName("Датум на одржување на настанот")]
        public string Datum { get; set; }
        [Required]
        [DisplayName("Слика")]
        public string Slika { get; set; }
       
        [Required]
        [DisplayName("Време на одржување на настанот")]
        public string Vreme { get; set; }
        [DisplayName("Организација")]
        public string Organizacija { get; set; }
    }
}