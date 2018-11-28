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

        public VendorDTO vendor { get; set; }

        public VendorViewModel()
        {

            vendorService = new VendorService();
            vendors = new ObservableCollection<VendorDTO>();
            vendor = new VendorDTO();
        }

        async public Task<bool> AddVendor(int categoryID, string name, bool status) {
            return await vendorService.AddVendor( categoryID,  name, status);
        }

        async public Task<bool> EditVendorByID(int vendorID, int categoryID, string name, bool status) {
            return await vendorService.EditVendorByID(vendorID, categoryID, name, status);
        }

        async public Task<bool> DeleteVendorByID(int vendorID) {
            return await vendorService.DeleteVendorByID(vendorID);
        }

        async public void GetAllVendors() {
            vendors = await vendorService.GetAllVendors();
        }

        async public void GetVendorByCategoryID(int category) {
            vendors = await vendorService.GetVendorByCategoryID(category);
        }

        async public void GetVendors(int category) {
            vendors = await vendorService.GetVendorByCategoryID(category);
        }

        async public void GetVendorByID(int vendorID) {
            vendor = await vendorService.GetVendorByID(vendorID);
        }

        async public void GetVendorByName(string vendorName) {
            vendors = await vendorService.GetVendorByName(vendorName);
        }

        async public void GetVendorByState(bool state) {
            vendors = await vendorService.GetVendorByState(state);
        }
    }
}
