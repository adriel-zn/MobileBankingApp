using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Mobile.Models
{
    public class Beneficiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public string BankCode { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
    }
}
