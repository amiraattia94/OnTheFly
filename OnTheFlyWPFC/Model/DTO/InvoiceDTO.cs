using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class InvoiceDTO
    {
        public int invoiceID { get; set; }
        public int custodyID { get; set; }
        public Nullable<int> issuerID { get; set; }
        public int customerID { get; set; }
        public DateTime time { get; set; }
        public Nullable<int> branchID { get; set; }
    }
}
