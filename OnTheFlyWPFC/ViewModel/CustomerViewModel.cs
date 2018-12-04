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
    class CustomerViewModel
    {

        CustomerService customerService;
        public ObservableCollection<CustomerDTO> ViewCustomers { get; set; }
        public ObservableCollection<MembershipDTO> ViewMembership { get; set; }
        public CustomerDTO customer { get; set; }
        public MembershipDTO membership { get; set; }

        public CustomerViewModel()
        {
            customerService = new CustomerService();
            ViewCustomers = new ObservableCollection<CustomerDTO>();
            ViewMembership = new ObservableCollection<MembershipDTO>();
            customer = new CustomerDTO();
            membership = new MembershipDTO();

            GetAllCustomers();
        }


        async public Task<bool> AddCustomer(string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit)
        {
            return await customerService.AddCustomer(CustomerName, CustomerPhone1, CustomerPhone2, cityCode, CustomerAddress, CustomerCredit);
        }

        async public Task<bool> EditCustomer(int CustomerID, string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit)
        {
            return await customerService.EditCustomerByID(CustomerID, CustomerName, CustomerPhone1, CustomerPhone2, cityCode, CustomerAddress, CustomerCredit);
        }

        async public Task<bool> RemoveCreditFromCustomer(int CustomerID, decimal SpentCredit) {
            return await customerService.RemoveCreditFromCustomer(CustomerID, SpentCredit);
        }

        async public Task<bool> DeleteCustomerByID(int customerID)
        {
            return await customerService.DeleteCustomerByID(customerID);
        }

        async public void GetAllCustomers()
        {
            ViewCustomers = await customerService.GetAllCustomers();
        }

        async public void GetCustomerByCity(string cityCode)
        {
            ViewCustomers = await customerService.GetCustomerByCity(cityCode);
        }

        async public void GetCustomerByName(string cutsomerName)
        {
            ViewCustomers = await customerService.GetCustomerByName(cutsomerName);
        }

        async public void GetCustomerByID(int CustomerID)
        {

            customer = await customerService.GetCustomerByID(CustomerID);
        }

        async public Task<bool> AddMembership(string MembershipID, int CustomerID, int VendorID)
        {
            return await customerService.AddMembership(MembershipID, CustomerID, VendorID);
        }

        async public Task<bool> EditMembershipByID(string MembershipID, int VendorID)
        {
            return await customerService.EditMembershipByID(MembershipID, VendorID);
        }

        async public Task<bool> DeleteMembershipByID(string MembershipID)
        {
            return await customerService.DeleteMembershipByID(MembershipID);
        }

        async public void GetMembershipByCustomerID(int CustomerID)
        {
            ViewMembership = await customerService.GetMembershipByCustomerID(CustomerID);
        }

        async public void GetMembershipByID(string membershipID)
        {
            membership = await customerService.GetMembershipByID(membershipID);
        }

        async public void GetCustomerByMembershipID(string MembershipID)
        {
            ViewCustomers = await customerService.GetCustomerByMembershipID(MembershipID);
        }
    }
}
