using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel
{
    class VendorViewModel
    {

        VendorService vendorService;
        public ObservableCollection<VendorDTO> vendors { get; set; }

        public VendorViewModel() {

            vendorService = new VendorService();
            vendors = new ObservableCollection<VendorDTO>();
        }

        async public void GetVendors(int category) {
            vendors = await vendorService.GetVendorByCategoryID(category);
        }


    }
}
