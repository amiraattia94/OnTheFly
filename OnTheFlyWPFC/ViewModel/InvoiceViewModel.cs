using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel {
    class InvoiceViewModel {

        InvoiceService invoiceService;

        public InvoiceDTO invoice { get; set; }
        public string invoiceNewID { get; set; }

        public InvoiceViewModel() {

            invoiceService = new InvoiceService();
            invoice = new InvoiceDTO();
            invoiceNewID = "";

        }

        async public void GetNewInvoiceID() {
            invoiceNewID = await invoiceService.GetNewInvoiceID();
        }
    }
}
