using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agile9.outlook.context.db.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string ClientCompanyName { get; set; }
        public bool IsCompany { get; set; }
        public string TaxId { get; set; }
        public string ContactNumber { get; set; }
    }
}
