using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Volunteering.Models
{
    public class Prijava
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Име")]
        public string Ime { get; set; }
        [Required]
        [DisplayName("Презиме")]
        public string Prezime { get; set; }
        [Required]
        [DisplayName("Е-маил")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Е-маилот не е валиден")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Телефонски број")]
        [RegularExpression("07[015678]\\/\\d{3}\\-\\d{3}", ErrorMessage = "Телефонскиот број не е валиден")]
        public string Telefon { get; set; }
       

    }
}