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

        async public Task<bool> EditCustomerByID(int CustomerID, string CustomerName, string CustomerPhone1, string CustomerPhone2, string cityCode, string CustomerAddress, decimal CustomerCredit) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.customerTBLs.SingleOrDefault(w => w.customerID == CustomerID);
                    if (Result != null) {

                        try {
                            Result.name = CustomerName;
                            Result.phone1 = CustomerPhone1;
                            Result.phone2 = CustomerPhone2;
                            Result.cityID = cityCode;
                            Result.address = CustomerAddress;
                            Result.credit = CustomerCredit;

                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch {

                        }
                        return false;
                    }
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
                    customerID = s.customerID,
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

        async public Task<CustomerDTO> GetCustomerByID(int customerID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.customerTBLs.SingleOrDefault(w => w.customerID == customerID);

                if (result != null) {
                    return new CustomerDTO() {
                        customerID = result.customerID,
                        name = result.name,
                        address = result.address,
                        phone1 = result.phone1,
                        phone2 = result.phone2,
                        city = result.LibyanCitiesTBL.name,
                        credit = result.credit


                    };
                };

                return new CustomerDTO() {
                    customerID = 0,
                    name = "0",
                    address = "0",
                    phone1 = "0",
                    phone2 = "0",
                    city = "0",
                    credit = 0
                };



            }
        }

        async public Task<ObservableCollection<CustomerDTO>> GetCustomerByName(string CustomerName) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {

                var result = con.customerTBLs.Where(w => w.name.StartsWith(CustomerName)).Select(s => new CustomerDTO() {
                    customerID = s.customerID,
                    name = s.name,
                    address = s.address,
                    phone1 = s.phone1,
                    phone2 =s.phone2,
                    credit = s.credit,
                    city = s.LibyanCitiesTBL.name
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<CustomerDTO>(result);
                }
                else {
                    return new ObservableCollection<CustomerDTO>();
                }
            }

        }

        async public Task<ObservableCollection<CustomerDTO>> GetCustomerByCity(string City) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.customerTBLs.Where(w => w.cityID == City).Select(s => new CustomerDTO() {
                    customerID = s.customerID,
                    name = s.name,
                    address = s.address,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    credit = s.credit,
                    city = s.LibyanCitiesTBL.name
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<CustomerDTO>(result);
                }
                else {
                    return new ObservableCollection<CustomerDTO>();
                }



            }

        }

        async public Task<bool> DeleteCustomerByID(int CustomerID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.customerTBLs.SingleOrDefault(w => w.customerID == CustomerID);

                    if (result != null) {
                        con.customerTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }


    }
}
