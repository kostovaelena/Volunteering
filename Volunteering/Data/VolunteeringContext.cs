using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Volunteering.Data
{
    public class VolunteeringContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VolunteeringContext() : base("name=VolunteeringContext")
        {
        }

        public System.Data.Entity.DbSet<Volunteering.Models.Kategorija> Kategorijas { get; set; }

       

        public System.Data.Entity.DbSet<Volunteering.Models.VolonterskiAngazman> VolonterskiAngazmen { get; set; }

        public System.Data.Entity.DbSet<Volunteering.Models.Organizacija> Organizacijas { get; set; }

        public System.Data.Entity.DbSet<Volunteering.Models.Prijava> Prijavas { get; set; }

        public System.Data.Entity.DbSet<Volunteering.Models.Doniraj> Donirajs { get; set; }
        public System.Data.Entity.DbSet<Volunteering.Models.Forum> Forums { get; set; }
       



    }
}
