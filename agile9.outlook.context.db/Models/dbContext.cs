using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace agile9.outlook.context.db.Models
{
    public class dbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public dbContext() : base("name=dbContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.Report> Reports { get; set; }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.Person> Person { get; set; }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.JobType> JobType { get; set; }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.Car> Cars { get; set; }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.Insurance> Insurances { get; set; }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<agile9.outlook.context.db.Models.Job> Jobs { get; set; }
    
    }
}
