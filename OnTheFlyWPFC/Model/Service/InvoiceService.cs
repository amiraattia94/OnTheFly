using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class InvoiceService {


        async public Task<bool> AddInvoice(int issuerID, int customerID,decimal discount, int deliveryID,decimal totalcost, int? custodyID ) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var issued = con.invoiceTBLs.OrderByDescending(w => w.invoiceID).First().issued;

                    if (issued) {
                        try {
                            con.invoiceTBLs.Add(new invoiceTBL() {

                                invoiceID = await GetInvoiceID(),
                                issuerID = issuerID,
                                custodyID = custodyID,
                                customerID = customerID,
                                time = DateTime.Now,
                                issued = true,
                                discount = discount,
                                deliveryID = deliveryID,
                                totalcost = totalcost


                            });
                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch (Exception) {

                            
                        }
                        return false;


                    }
                    else if(issued == false) {

                        var invoiceID = await GetInvoiceID();
                        var Result = con.invoiceTBLs.SingleOrDefault(w => w.invoiceID == invoiceID);

                        if (Result != null) {

                            try {
                                Result.invoiceID = invoiceID;
                                Result.issuerID = issuerID;
                                Result.custodyID = custodyID;
                                Result.customerID = customerID;
                                Result.time = DateTime.Now;
                                Result.issued = true;
                                Result.discount = discount;
                                Result.deliveryID = deliveryID;
                                Result.totalcost = totalcost;

                                await con.SaveChangesAsync();
                                return true;
                            }
                            catch {

                            }
                            return false;
                        }
                    }

                    
                }
            }
            catch (Exception) {

                
            }
            return false;
        }

        async public Task<ObservableCollection<InvoiceDTO>> GetAllInvoice() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.invoiceTBLs.Select(s => new InvoiceDTO() {
                    invoiceID = s.invoiceID,
                    dateTime = s.time,
                    customername = s.CustomerTBL.name,
                    phone1 = s.CustomerTBL.phone1,
                    phone2 = s.CustomerTBL.phone2,
                    customercityCodee = s.CustomerTBL.LibyanCitiesTBL.city_code,
                    customerCityname = s.CustomerTBL.LibyanCitiesTBL.name,
                    customerAddress = s.CustomerTBL.address,
                    customerID = s.CustomerTBL.customerID,
                    DriverID = s.deliveryTBL.driverID,
                    DriverName = s.deliveryTBL.EmployeeTBL.name,
                    branchID = s.UserTBL.EmployeeTBL.branchID,
                    issuerID = s.issuerID,
                    issuerName = s.UserTBL.EmployeeTBL.name,
                    ServiceNumber = s.ServiceTBLs.Count(),
                    discount = (decimal)s.discount,
                    totalafter = (decimal)s.totalcost,
                    custodyID = s.custodyID
                    

                }).ToList();

                return new ObservableCollection<InvoiceDTO>(result);
            }
        }

        async public Task<InvoiceDTO> GetInvoiceByID(int invoiceID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var s = con.invoiceTBLs.SingleOrDefault(w => w.invoiceID == invoiceID);
                try {
                    if (s != null) {
                        return new InvoiceDTO() {
                            invoiceID = s.invoiceID,
                            dateTime = s.time,
                            customername = s.CustomerTBL.name,
                            phone1 = s.CustomerTBL.phone1,
                            phone2 = s.CustomerTBL.phone2,
                            customercityCodee = s.CustomerTBL.LibyanCitiesTBL.city_code,
                            customerCityname = s.CustomerTBL.LibyanCitiesTBL.name,
                            customerAddress = s.CustomerTBL.address,
                            customerID = s.CustomerTBL.customerID,
                            DriverID = s.deliveryTBL.driverID,
                            DriverName = s.deliveryTBL.EmployeeTBL.name,
                            branchID = s.UserTBL.EmployeeTBL.branchID,
                            issuerID = s.issuerID,
                            issuerName = s.UserTBL.EmployeeTBL.name,
                            ServiceNumber = s.ServiceTBLs.Count(),
                            discount = (decimal)s.discount,
                            totalafter = (decimal)s.totalcost,
                            custodyID = s.custodyID
                        };
                    };
                }
                catch (Exception) {

                }

                return new InvoiceDTO() { };



            }
        }

        async public Task<int> GetInvoiceID() {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                int r = 0;
                try {
                    var result = con.invoiceTBLs.OrderByDescending(w => w.invoiceID).First();
                    if (result != null) {
                        if (result.issued == false) {

                            return result.invoiceID;
                        }
                        if (result.issued == true) {
                            con.invoiceTBLs.Add(new invoiceTBL() {

                                invoiceID = result.invoiceID + 1,
                                time = DateTime.Now,
                                issued = false


                            });
                            await con.SaveChangesAsync();
                            return result.invoiceID + 1;


                        }

                    };
                }
                catch (Exception) {

                }
                return r;
            }
        }

        async public Task<decimal?> GetTotalPriceByInvoiceID(int invoiceID) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                decimal? result;
                try {

                    return result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == invoiceID).Select(s=>s.deliveryPrice + s.productPrice).Sum();
                    
                }
                catch (Exception) {

                }
                return result = 0;
            }
        }

        async public Task<decimal?> GetTotalDeliveryPriceByInvoiceID(int invoiceID) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                decimal? result;
                try {

                    return result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == invoiceID).Select(s => s.deliveryPrice).Sum();

                }
                catch (Exception) {

                }
                return result = 0;
            }
        }

        async public Task<DateTime?> GetLastDeliveryItemDateByInvoiceID(int invoiceID) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                DateTime? result = null;
                try {

                    return result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == invoiceID).Select(s => s.availabilityDay).Max();

                }
                catch (Exception) {

                }
                return result;
            }
        }

        async public Task<DateTime?> GetFirstDeliveryItemDateByInvoiceID(int invoiceID) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                DateTime? result = null;
                try {

                    return result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == invoiceID).Select(s => s.availabilityDay).Min();

                }
                catch (Exception) {

                }
                return result;
            }
        }



        async public Task<bool> AddDeliveryService(int invoiceID, int categoreID, int vendorBranchID, int customerID, bool isFullTrip, decimal productPrice, decimal deliveryPrice ,bool status,DateTime avilable) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.DeliveryServiceTBLs.Add(new DeliveryServiceTBL() {

                        invoiceID = invoiceID,
                        categoryID = categoreID,
                        vendorBranchID = vendorBranchID,
                        customerID = customerID,
                        isFullTrip = isFullTrip,
                        productPrice = productPrice,
                        deliveryPrice = deliveryPrice,
                        status = status,
                        availabilityDay = avilable


                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> EditDeliveryService(int deliveryServiceID, int invoiceID, int categoreID, int vendorBranchID, int customerID, bool isFullTrip, decimal productPrice, decimal deliveryPrice, bool status, DateTime avilable) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.DeliveryServiceTBLs.SingleOrDefault(w => w.deliveryServiceID == deliveryServiceID);
                    if (Result != null) {

                        try {
                            Result.invoiceID = invoiceID;
                            Result.categoryID = categoreID;
                            Result.vendorBranchID = vendorBranchID;
                            Result.customerID = customerID;
                            Result.isFullTrip = isFullTrip;
                            Result.productPrice = productPrice;
                            Result.deliveryPrice = deliveryPrice;
                            Result.status = status;
                            Result.availabilityDay = avilable;

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

        async public Task<bool> DeleteDeliveryServiceByID(int deliveryServiceID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.DeliveryServiceTBLs.SingleOrDefault(w => w.deliveryServiceID == deliveryServiceID);

                    if (result != null) {
                        con.DeliveryServiceTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }

        async public void DeleteAllDeliveryServiceByinvoice(int invoiceID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == invoiceID);


                    if (result != null) {
                        con.DeliveryServiceTBLs.RemoveRange(result);
                        await con.SaveChangesAsync();
                    };

                }
            }
            catch {

            }
        }

        async public Task<ObservableCollection<DeliveryServiceDTO>> GetAllDeliveryServices() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryServiceTBLs.Where(w =>w.invoiceID == HelperClass.POSInvoiceID).Select(s => new DeliveryServiceDTO() {
                    deliverServiceID = s.deliveryServiceID,
                    CategoryID = s.categoryID,
                    CategoryName = s.CategoriesTBL.category_name,
                    VendorID = s.VendorBranchTBL.VendorTBL.vendorID,
                    VendorName = s.VendorBranchTBL.VendorTBL.name,
                    VendorBranchID = s.vendorBranchID,
                    VendorCityCode = s.VendorBranchTBL.cityID,
                    VendorCityname = s.VendorBranchTBL.LibyanCitiesTBL.name,
                    CustomerID = s.customerID,
                    Customername = s.CustomerTBL.name,
                    CustomerCityCode = s.CustomerTBL.cityID,
                    isFulTrip = s.isFullTrip,
                    productPrice = s.productPrice,
                    deliveryPrice = s.deliveryPrice,
                    InvoiceID = s.invoiceID,
                    dateAvailable = s.availabilityDay,
                    status = false
                }).ToList();

                return new ObservableCollection<DeliveryServiceDTO>(result);
            }
        }

        async public Task<ObservableCollection<DeliveryServiceDTO>> GetAllDeliveryServicesByInvoice(int InvoiceID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == InvoiceID).Select(s => new DeliveryServiceDTO() {
                    deliverServiceID = s.deliveryServiceID,
                    CategoryID = s.categoryID,
                    CategoryName = s.CategoriesTBL.category_name,
                    VendorID = s.VendorBranchTBL.VendorTBL.vendorID,
                    VendorName = s.VendorBranchTBL.VendorTBL.name,
                    VendorBranchID = s.vendorBranchID,
                    VendorCityCode = s.VendorBranchTBL.cityID,
                    VendorCityname = s.VendorBranchTBL.LibyanCitiesTBL.name,
                    CustomerID = s.customerID,
                    Customername = s.CustomerTBL.name,
                    CustomerCityCode = s.CustomerTBL.cityID,
                    isFulTrip = s.isFullTrip,
                    productPrice = s.productPrice,
                    deliveryPrice = s.deliveryPrice,
                    InvoiceID = s.invoiceID,
                    dateAvailable = s.availabilityDay,
                    status = false
                }).ToList();

                return new ObservableCollection<DeliveryServiceDTO>(result);
            }
        }

        async public Task<DeliveryServiceDTO> GetDeliveryServiceByID(int deliveryServiceID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryServiceTBLs.SingleOrDefault(w => w.deliveryServiceID == deliveryServiceID);

                if (result != null) {
                    return new DeliveryServiceDTO() {
                        deliverServiceID = result.deliveryServiceID,
                        CategoryID = result.categoryID,
                        CategoryName = result.CategoriesTBL.category_name,
                        VendorID = result.VendorBranchTBL.VendorTBL.vendorID,
                        VendorName = result.VendorBranchTBL.VendorTBL.name,
                        VendorBranchID = result.vendorBranchID,
                        VendorCityCode = result.VendorBranchTBL.cityID,
                        VendorCityname = result.VendorBranchTBL.LibyanCitiesTBL.name,
                        CustomerID = result.customerID,
                        Customername = result.CustomerTBL.name,
                        CustomerCityCode = result.CustomerTBL.cityID,
                        isFulTrip = result.isFullTrip,
                        productPrice = result.productPrice,
                        deliveryPrice = result.deliveryPrice,
                        InvoiceID = result.invoiceID,
                        dateAvailable = result.availabilityDay,
                        status = false


                    };
                };

                return new DeliveryServiceDTO() {};



            }
        }



        async public Task<bool> AddDelivery(int? carID, int driverID, DateTime? startday, DateTime? enddate, int status, DateTime? firstItemDate, DateTime? lastItemDate) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = new deliveryTBL() {
                        carID = carID,
                        driverID = driverID,
                        start_date = startday,
                        end_date = enddate,
                        statusID = status,
                        firstItemAvailableDate = firstItemDate,
                        lastItemAvailableDate = lastItemDate,

                    };
                    con.deliveryTBLs.Add(result);
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<int> AddDeliveryInt(int? carID, int driverID, DateTime? startday,DateTime? enddate, int status,DateTime?  firstItemDate,DateTime? lastItemDate) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = new deliveryTBL() {
                        carID = carID,
                        driverID = driverID,
                        start_date = startday,
                        end_date = enddate,
                        statusID = status,
                        firstItemAvailableDate = firstItemDate,
                        lastItemAvailableDate = lastItemDate,

                    };
                    con.deliveryTBLs.Add(result);
                    await con.SaveChangesAsync();
                    return result.deliveryID;
                }
            }
            catch (Exception) {

            }
            return 0;
        }

        async public Task<bool> EditDelivery(int deliveryID, DateTime? startday, DateTime? enddate, int status, DateTime? firstItemDate, DateTime? lastItemDate) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.deliveryTBLs.SingleOrDefault(w => w.deliveryID == deliveryID);
                    if (Result != null) {

                        try {
                            
                            Result.start_date = startday;
                            Result.end_date = enddate;
                            Result.statusID = status;
                            Result.firstItemAvailableDate = firstItemDate;
                            Result.lastItemAvailableDate = lastItemDate;

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

        async public Task<ObservableCollection<DeliveryDTO>> GetAllDelivery(int deliveryID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.deliveryTBLs.Where(w => w.deliveryID == deliveryID).Select(s => new DeliveryDTO() {
                    custodyID = s.invoiceTBL.custodyID,
                    driverID = s.driverID,
                    driverName = s.EmployeeTBL.name,
                    customername = s.invoiceTBL.CustomerTBL.name,
                    customercityCodee = s.invoiceTBL.CustomerTBL.LibyanCitiesTBL.city_code,
                    customerCityname = s.invoiceTBL.CustomerTBL.LibyanCitiesTBL.name,
                    customerAddress = s.invoiceTBL.CustomerTBL.address,
                    phone1 = s.invoiceTBL.CustomerTBL.phone1,
                    phone2 = s.invoiceTBL.CustomerTBL.phone2,
                    deliveryID = s.deliveryID,
                    invoiceID = s.invoiceID,
                    start_date = s.start_date,
                    end_date = s.end_date,
                    firstItemdate =s.firstItemAvailableDate,
                    lastItemDate = s.lastItemAvailableDate,
                    ServicesCount = s.invoiceTBL.DeliveryServiceTBLs.Count,
                    status = s.statusID,
                    statusName = s.DeliveryStatusTBL.name,
                    totalCustodycost = s.invoiceTBL.custodyTBL.amount,
                    totalcost = s.invoiceTBL.totalcost,

                    

                }).ToList();

                return new ObservableCollection<DeliveryDTO>(result);
            }
        }

        async public Task<DeliveryDTO> GetDeliveryByID(int deliveryID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.deliveryTBLs.SingleOrDefault(w => w.deliveryID == deliveryID);

                if (result != null) {
                    return new DeliveryDTO() {
                        custodyID = result.invoiceTBL.custodyID,
                        driverID = result.driverID,
                        driverName = result.EmployeeTBL.name,
                        customername = result.invoiceTBL.CustomerTBL.name,
                        customercityCodee = result.invoiceTBL.CustomerTBL.LibyanCitiesTBL.city_code,
                        customerCityname = result.invoiceTBL.CustomerTBL.LibyanCitiesTBL.name,
                        customerAddress = result.invoiceTBL.CustomerTBL.address,
                        phone1 = result.invoiceTBL.CustomerTBL.phone1,
                        phone2 = result.invoiceTBL.CustomerTBL.phone2,
                        deliveryID = result.deliveryID,
                        invoiceID = result.invoiceID,
                        start_date = result.start_date,
                        end_date = result.end_date,
                        firstItemdate = result.firstItemAvailableDate,
                        lastItemDate = result.lastItemAvailableDate,
                        ServicesCount = result.invoiceTBL.DeliveryServiceTBLs.Count,
                        status = result.statusID,
                        statusName = result.DeliveryStatusTBL.name,
                        totalCustodycost = result.invoiceTBL.custodyTBL.amount,
                        totalcost = result.invoiceTBL.totalcost,



                    };
                };

                return new DeliveryDTO() { };



            }
        }



        async public Task<bool> AddCustody(int OwnerID, decimal ammount, bool status,int invoiceID) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.custodyTBLs.Add(new custodyTBL() {


                        ownerID = OwnerID,
                        amount = ammount,
                        active = status,
                        invoiceID = invoiceID,
                        

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<int> AddCustodyInt(int OwnerID, decimal ammount, bool status, int invoiceID) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = new custodyTBL() {


                        ownerID = OwnerID,
                        amount = ammount,
                        active = status,
                        invoiceID = invoiceID,


                    };

                    con.custodyTBLs.Add(result);
                    await con.SaveChangesAsync();
                    return result.custodyID;
                }
            }
            catch (Exception) {

            }
            return 0;
        }

        async public Task<bool> EditCustody(int custodyID, bool status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.custodyTBLs.SingleOrDefault(w => w.custodyID == custodyID);
                    if (Result != null) {

                        try {

                            Result.active = status;
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

        async public Task<bool> DeleteCustody(int custodyID) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.custodyTBLs.SingleOrDefault(w => w.custodyID == custodyID);

                    if (result != null) {
                        con.custodyTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };
                
                }
            }
            catch (Exception) {

            }
            return false;

        }

        async public Task<ObservableCollection<CustodyDTO>> GetAllCustody() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.custodyTBLs.Select(s => new CustodyDTO() {
                    actve = s.active,
                    amount = s.amount,
                    custodyID = s.custodyID,
                    deliveryID = s.invoiceTBL.deliveryID,
                    invoiceID = s.invoiceID,
                    ownerID =s.ownerID,
                    ownerName = s.EmployeeTBL.name,
                    giverName = s.invoiceTBL.UserTBL.EmployeeTBL.name,



                }).ToList();

                return new ObservableCollection<CustodyDTO>(result);
            }
        }

        async public Task<CustodyDTO> GetCustodyByID(int CustodyID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.custodyTBLs.SingleOrDefault(w => w.custodyID == CustodyID);

                if (result != null) {
                    return new CustodyDTO() {
                        actve = result.active,
                        amount = result.amount,
                        custodyID = result.custodyID,
                        deliveryID = result.invoiceTBL.deliveryID,
                        invoiceID = result.invoiceID,
                        ownerID = result.ownerID,
                        ownerName = result.EmployeeTBL.name,
                        giverName = result.invoiceTBL.UserTBL.EmployeeTBL.name,




                    };
                };

                return new CustodyDTO() { };



            }
        }

    }
}
