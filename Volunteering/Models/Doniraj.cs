using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Volunteering.Models
{
    public class Doniraj
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public int Suma { set; get; }
        public List<Organizacija> organizacii { set; get; }
      
       


    }

}