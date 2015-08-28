using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agile9.outlook.context.db.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return this.Name + " " + this.Surname; } }

        public int JobTypeId { get; set; }
        public virtual JobType JobType { get; set; }
        public string JobTitle { get { return this.JobType.Title; } }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}