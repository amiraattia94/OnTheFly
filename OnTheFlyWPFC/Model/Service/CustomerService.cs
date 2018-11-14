using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class CustomerService {
        async public Task<bool> AddCustomer(string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.customerTBLs.Add(new customerTBL() {
                        name = CustomerName,
                        phone1 = CustomerPhone1,
                        phone2 = CustomerPhone2,
                        cityID = cityCode,
                        address = CustomerAddress,
                        credit = CustomerCredit,
                        add_date = DateTime.Now.Date

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<ObservableCollection<CustomerDTO>> GetAllCustomers() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.customerTBLs.Select(s => new CustomerDTO() {
                    name = s.name,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    address = s.address,
                    city = s.LibyanCitiesTBL.name,
                    adddate = s.add_date.ToString(),
                    credit = s.credit
                    
                }).ToList();

                return new ObservableCollection<CustomerDTO>(result);
            }
        }

        }
}
