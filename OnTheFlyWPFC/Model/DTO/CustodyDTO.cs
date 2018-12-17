using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class CustodyDTO
    {
        public int custodyID { get; set; }
        public int ownerID { get; set; }
        public decimal? amount { get; set; }
        public bool actve { get; set; }
        public string stateName { get; set; }
        public int? deliveryID { get; set; }

        public int? invoiceID { get; set; }

        public string ownerName { get; set; }

        public string giverName { get; set; }



    }
}
