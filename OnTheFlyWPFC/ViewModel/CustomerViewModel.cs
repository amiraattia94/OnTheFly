using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel {
    class CustomerViewModel {

        CustomerService customerService;
        public ObservableCollection<CustomerDTO> ViewCustomers { get; set; }
        public CustomerDTO customer { get; set; }

        public CustomerViewModel() {
            customerService = new CustomerService();
            ViewCustomers = new ObservableCollection<CustomerDTO>();
            customer = new CustomerDTO();

            GetAllCustomers();
        }


        async public Task<bool> AddCustomer(string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit) {
            return await customerService.AddCustomer(CustomerName, CustomerPhone1, CustomerPhone2, cityCode, CustomerAddress, CustomerCredit);
        }

        async public Task<bool> EditCustomer(int CustomerID, string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit) {
            return await customerService.EditCustomerByID(CustomerID, CustomerName, CustomerPhone1, CustomerPhone2, cityCode, CustomerAddress, CustomerCredit);
        }

        async public Task<bool> DeleteCustomerByID(int customerID) {
            return await customerService.DeleteCustomerByID(customerID);
        }

        async public void GetAllCustomers() {
            ViewCustomers = await customerService.GetAllCustomers();
        }

        async public void GetCustomerByCity(string cityCode) {
            ViewCustomers = await customerService.GetCustomerByCity(cityCode);
        }

        async public void GetCustomerByName(string cutsomerName) {
            ViewCustomers = await customerService.GetCustomerByName(cutsomerName);
        }

        async public void GetCustomerByID(int CustomerID) {

            customer = await customerService.GetCustomerByID(CustomerID);
        }




    }
}
