using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agile9.outlook.context.db.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Revenues { get; set; }
        public double Expenses { get; set; }
        public double Profit { get; set; }
        public double ProfitAfterTax { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        
    }
}
