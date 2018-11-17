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

        async public void GetAllCustomers() {
            ViewCustomers = await customerService.GetAllCustomers();
        }

        async public Task<bool> AddCustomer(string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit) {
            return await customerService.AddCustomer(CustomerName, CustomerPhone1, CustomerPhone2, cityCode, CustomerAddress, CustomerCredit);
        }

        


    }
}
