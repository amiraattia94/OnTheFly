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
        public ObservableCollection<VendorBranchsDTO> vendorBranches { get; set; }

        public VendorDTO vendor { get; set; }
        public VendorBranchsDTO vendorBranche { get; set; }

        public VendorViewModel()
        {

            vendorService = new VendorService();
            vendors = new ObservableCollection<VendorDTO>();
            vendor = new VendorDTO();

            vendorBranches = new ObservableCollection<VendorBranchsDTO>();

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

        async public Task<bool> AddVendorBranch(int vendorID, string name, string citycode, string address, string phone1, string phone2, bool state) {
            return await vendorService.AddVendorBranch(vendorID, name, citycode, address, phone1, phone2, state);
        }

        async public Task<bool> EditVendorBranchByID(int vendorBranchID, string name, string citycode, string address, string phone1, string phone2, bool state) {
            return await vendorService.EditVendorBranchByID(vendorBranchID, name, citycode, address, phone1, phone2, state);
        }

        async public Task<bool> DeleteVendorBranchByID(int vendorBranchID) {
            return await vendorService.DeleteVendorBranchByID(vendorBranchID);
        }

        async public void GetAllVendorBranchByID(int BranchByID) {
            vendorBranches = await vendorService.GetAllVendorBranchByID( BranchByID);
        }

        async public void GetVendorBranchshipByID(int vendorBranshID) {
            vendorBranche = await vendorService.GetVendorBranchshipByID( vendorBranshID);
        }

    }
}
