using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class InvoiceService {

        async public Task<string> GetNewInvoiceID() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                string temp = "";
                try {
                    var result = con.invoiceTBLs.OrderByDescending(w => w.invoiceID).First();
                    if (result != null) {
                        var a = result.invoiceID + 1;
                        temp = a.ToString("D8");
                    };
                }
                catch (Exception) {
                    
                }
                return temp = "";
            }
        }
    }
}
