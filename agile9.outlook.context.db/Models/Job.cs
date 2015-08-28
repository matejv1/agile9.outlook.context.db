using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agile9.outlook.context.db.Models
{
    public class Job
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public double Tax { get; set; }
        public string BillNumber { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public int InsuranceId { get; set; }
        public virtual Insurance Insurance { get; set; }

    }
}
