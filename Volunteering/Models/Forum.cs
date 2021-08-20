using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Volunteering.Models
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Име")]
        [Required]
        public string Ime { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Коментар")]
        [Required]
        public string Comment { get; set; }

        public DateTime WhenCreated { get; set; }

        public Forum ()
        {
           WhenCreated = DateTime.Now;
        }
    }
}