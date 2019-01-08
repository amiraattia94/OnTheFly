using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class InvoiceService {


        async public Task<bool> AddInvoice(int issuerID, int? customerID,decimal discount, int? deliveryID,decimal totalcost,decimal totaldeliveryPrice, int? custodyID ) {
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
                                totalcost = totalcost,
                                totaldelivery = totaldeliveryPrice,
                                returned = false,


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
                                Result.totaldelivery = totaldeliveryPrice;
                                Result.returned = false;
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

        async public Task<bool> DeleteInvoiceByID(int InvoiceID)
        {
            await Task.FromResult(true);

            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.invoiceTBLs.SingleOrDefault(w => w.invoiceID == InvoiceID);
                    if (Result != null)
                    {

                        try
                        {
                            Result.returned = true;

                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {

                        }
                        return false;
                    }


                }
            }
            catch
            {

            }

            return false;

        }


        async public Task<ObservableCollection<InvoiceDTO>> GetAllInvoice() {
            await Task.FromResult(true);

            
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                try {

                    var result = con.invoiceTBLs.Where(w => w.issuerID != null).Select(s => new InvoiceDTO() {
                        invoiceID = s.invoiceID,
                        dateTime = s.time,

                        customerID = s.CustomerTBL.customerID,
                        customername = s.CustomerTBL.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerName : s.CustomerTBL.name,
                        customerCityname = s.CustomerTBL.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).cityName : s.CustomerTBL.LibyanCitiesTBL.name,
                        customerAddress = s.CustomerTBL.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerAddress : s.CustomerTBL.address,

                        phone1 = s.CustomerTBL.phone1,
                        phone2 = s.CustomerTBL.phone2,
                        DriverID = s.deliveryTBL.driverID,
                        DriverName = s.deliveryTBL.EmployeeTBL.name,
                        branchID = s.UserTBL.EmployeeTBL.branchID,
                        issuerID = s.issuerID,
                        issuerName = s.UserTBL.EmployeeTBL.name,
                        ServiceNumber = s.DeliveryServiceTBLs.Count(),
                        discount = (decimal)s.discount,
                        totalafter = (decimal)s.totalcost,
                        custodyID = s.custodyID,
                        


                    }).OrderByDescending(o => o.invoiceID).ToList();

                    return new ObservableCollection<InvoiceDTO>(result);
                }
                catch (Exception ex) {
                    var m = ex.Message;
                    
                }
                return new ObservableCollection<InvoiceDTO>();
            }
        }

        async public Task<InvoiceDTO> GetInvoiceByID(int invoiceID){
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var s = con.invoiceTBLs.SingleOrDefault(w => w.invoiceID == invoiceID);
                try {
                    if (s != null) {
                        //var r = new InvoiceDTO() {
                        //invoiceID = s.invoiceID,
                        //dateTime = s.time,

                        ////customerID = s.CustomerTBL  == null ? <null> : s.CustomerTBL.customerID,
                        ////phone1 = s.CustomerTBL.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerPhone.ToString() : s.CustomerTBL.phone1,
                        ////phone2 = s.CustomerTBL.customerID == null ? "" : s.CustomerTBL.phone2,
                        ////customername = s.CustomerTBL.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerName : s.CustomerTBL.name,
                        ////customerCityname = s.CustomerTBL.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).cityName : s.CustomerTBL.LibyanCitiesTBL.name,
                        ////customerAddress = s.CustomerTBL.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerAddress : s.CustomerTBL.address,
                        ////customercityCodee =  s.CustomerTBL.customerID == null ? "" : s.CustomerTBL.LibyanCitiesTBL.city_code,

                        ////customername = s.CustomerTBL.name,
                        ////customercityCodee = s.CustomerTBL.LibyanCitiesTBL.city_code,
                        ////customerCityname = s.CustomerTBL.LibyanCitiesTBL.name,
                        ////customerAddress = s.CustomerTBL.address,
                        //DriverID = s.deliveryTBL.driverID,
                        //DriverName = s.deliveryTBL.EmployeeTBL.name,
                        //branchID = s.UserTBL.EmployeeTBL.branchID,
                        //issuerID = s.issuerID,
                        //issuerName = s.UserTBL.EmployeeTBL.name,
                        //ServiceNumber = s.DeliveryServiceTBLs.Count(),
                        //discount = (decimal)s.discount,
                        //totalafter = (decimal)s.totalcost,
                        //custodyID = s.custodyID,
                        ////totalBefore = s.CustomerTBL.customerID == null ? (decimal)(s.QuickDeliveryServiceTBLs.Where(w => w.invoiceID==invoiceID).Select(x => x.deliveryPrice + x.productPrice).Sum())  : (decimal)s.DeliveryServiceTBLs.Where(w => w.invoiceID == invoiceID).Select(x => x.deliveryPrice + x.productPrice).Sum(),
                        //InvoiceState = s.returned,
                        //DeliveryID = s.deliveryID,
                        //deliveryPriceAfter = s.totaldelivery,
                        //};
                        //return r;

                        var r = new InvoiceDTO() { };
                        r.customerID = s.customerID;
                        r.invoiceID = s.invoiceID;
                        r.dateTime = s.time;

                        r.phone1 = s.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerPhone.ToString() : s.CustomerTBL.phone1;
                        r.phone2 = s.customerID == null ? "" : s.CustomerTBL.phone2;
                        r.customername = s.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerName : s.CustomerTBL.name;
                        r.customerCityname = s.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).cityName : s.CustomerTBL.LibyanCitiesTBL.name;
                        r.customerAddress = s.customerID == null ? (s.QuickDeliveryServiceTBLs.FirstOrDefault(w => w.invoiceID == s.invoiceID)).customerAddress : s.CustomerTBL.address;
                        r.customercityCodee = s.customerID == null ? "" : s.CustomerTBL.LibyanCitiesTBL.city_code;
                        r.DriverID = s.deliveryTBL.driverID;
                        r.DriverName = s.deliveryTBL.EmployeeTBL.name;
                        r.branchID = s.UserTBL.EmployeeTBL.branchID;
                        r.issuerID = s.issuerID;
                        r.issuerName = s.UserTBL.EmployeeTBL.name;
                        r.ServiceNumber = s.DeliveryServiceTBLs.Count();
                        r.discount = (decimal)s.discount;
                        r.totalafter = (decimal)s.totalcost;
                        r.custodyID = s.custodyID;

                        decimal? add = 0;
                        try {
                            var b = con.QuickDeliveryServiceTBLs.SingleOrDefault(w => w.invoiceID == invoiceID);
                            add = b.productPrice + b.deliveryPrice;
                        }
                        catch (Exception) {
                            
                        }

                        r.totalBefore = s.customerID == null ? (decimal)(add == null ? 0 : add) : (decimal)s.DeliveryServiceTBLs.Where(w => w.invoiceID == invoiceID).Select(x => x.deliveryPrice + x.productPrice).Sum();
                        r.InvoiceState = s.returned;
                        r.DeliveryID = s.deliveryID;
                        r.deliveryPriceAfter = s.totaldelivery;
                        
                    return r;

                    };
                }
                catch (Exception ex) {
                    var t = ex.Message;
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
                var result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == HelperClass.POSInvoiceID).Select(s => new DeliveryServiceDTO() {
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
                    isFulTripName = (s.isFullTrip == true) ? "كاملة" : "نصف",
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
                    isFulTripName = (s.isFullTrip == true) ? "كاملة" : "نصف",

                    productPrice = s.productPrice,
                    deliveryPrice = s.deliveryPrice,
                    InvoiceID = s.invoiceID,
                    dateAvailable = s.availabilityDay,
                    status = false
                }).ToList();

                if(result.Count == 0) {
                    var result2 = con.QuickDeliveryServiceTBLs.SingleOrDefault(w => w.invoiceID == InvoiceID);
                    if (result2 != null) {
                        var temp = new ObservableCollection<DeliveryServiceDTO>();

                        temp.Add(new DeliveryServiceDTO() {
                            CategoryName = result2.categoryName,
                            Customername = result2.customerName,
                            VendorName = result2.distination,
                            isFulTrip = (bool)result2.isFullTrip,
                            isFulTripName = (result2.isFullTrip == true) ? "كاملة" : "نصف",
                            productPrice = result2.productPrice,
                            deliveryPrice = (decimal)result2.deliveryPrice,
                            InvoiceID = result2.invoiceID,
                            status = false,
                        });

                        return temp;
                    };
                }

                return new ObservableCollection<DeliveryServiceDTO>(result);
            }
        }

        async public Task<ObservableCollection<DeliveryServiceDTO2>> GetAllDeliveryServicesByInvoice2(int InvoiceID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryServiceTBLs.Where(w => w.invoiceID == InvoiceID).Select(s => new DeliveryServiceDTO2() {
                    deliverServiceID = s.deliveryServiceID,
                    CategoryID = s.categoryID,
                    CategoryName = s.CategoriesTBL.category_name,
                    VendorID = s.VendorBranchTBL.VendorTBL.vendorID,
                    VendorName = s.VendorBranchTBL.VendorTBL.name,
                    VendorBranchID = s.vendorBranchID,
                    VendorBranchN = s.VendorBranchTBL.name,
                    VendorCityCode = s.VendorBranchTBL.cityID,
                    VendorCityname = s.VendorBranchTBL.LibyanCitiesTBL.name,
                    CustomerID = s.customerID == null ? 0 : (int)s.customerID,
                    Customername = s.CustomerTBL.name,
                    CustomerCityCode = s.CustomerTBL.cityID,
                    isFulTrip = s.isFullTrip,
                    isFulTripName = (s.isFullTrip == true) ? "كاملة" : "نصف",
                    productPrice = s.productPrice == null ? 0 : (decimal)s.productPrice,
                    deliveryPrice = s.deliveryPrice,
                    InvoiceID = s.invoiceID,
                    dateAvailable =  s.availabilityDay == null ? DateTime.Now : (DateTime)s.availabilityDay,
                    status = false
                }).ToList();

                return new ObservableCollection<DeliveryServiceDTO2>(result);
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
                        isFulTripName = (result.isFullTrip == true) ? "كاملة" : "نصف",
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



        async public Task<bool> AddDelivery(int? carID, int driverID, DateTime? startday, DateTime? enddate, int status, DateTime? firstItemDate, DateTime? lastItemDate,int invoiceID) {
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
                        invoiceID = invoiceID,

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

        async public Task<int> AddDeliveryInt(int? carID, int driverID, DateTime? startday,DateTime? enddate, int status,DateTime?  firstItemDate,DateTime? lastItemDate,int invoiceID) {
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
                        invoiceID = invoiceID,

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

        async public Task<bool> EditDelivery(int deliveryID, int status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.deliveryTBLs.SingleOrDefault(w => w.deliveryID == deliveryID);
                    if (Result != null) {

                        try {
                            
                            Result.end_date = DateTime.Now;
                            Result.statusID = status;
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

        async public Task<ObservableCollection<DeliveryDTO>> GetAllDelivery() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                try {
                    var result = con.deliveryTBLs.Select(s => new DeliveryDTO() {
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
                        firstItemdate = s.firstItemAvailableDate,
                        lastItemDate = s.lastItemAvailableDate,
                        ServicesCount = s.invoiceTBL.DeliveryServiceTBLs.Count,
                        status = s.statusID,
                        statusName = s.deliveryStatusTBL.name,
                        totalCustodycost = s.invoiceTBL.custodyTBL.amount,
                        totalcost = s.invoiceTBL.totalcost,



                    }).ToList().OrderByDescending(o => o.invoiceID);

                    return new ObservableCollection<DeliveryDTO>(result);
                }
                catch (Exception) {

                }
                return new ObservableCollection<DeliveryDTO>();
            }
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
                    statusName = s.deliveryStatusTBL.name,
                    totalCustodycost = s.invoiceTBL.custodyTBL.amount,
                    totalcost = s.invoiceTBL.totalcost,

                    

                }).ToList();

                return new ObservableCollection<DeliveryDTO>(result);
            }
        }

        async public Task<ObservableCollection<DeliveryDTO>> GetAllDeliveryByStatus(int Status) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.deliveryTBLs.Where(w => w.statusID == Status).Select(s => new DeliveryDTO() {
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
                    firstItemdate = s.firstItemAvailableDate,
                    lastItemDate = s.lastItemAvailableDate,
                    ServicesCount = s.invoiceTBL.DeliveryServiceTBLs.Count,
                    status = s.statusID,
                    statusName = s.deliveryStatusTBL.name,
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
                    try {
                        return new DeliveryDTO() {
                            //custodyID = result.invoiceTBL.custodyID != null ? result.invoiceTBL.custodyID : null,
                            driverID = result.driverID,
                            //driverName = result.EmployeeTBL.name,
                            //customername = result.invoiceTBL.CustomerTBL.name,
                            //customercityCodee = result.invoiceTBL.CustomerTBL.LibyanCitiesTBL.city_code,
                            //customerCityname = result.invoiceTBL.CustomerTBL.LibyanCitiesTBL.name,
                            //customerAddress = result.invoiceTBL.CustomerTBL.address,
                            //phone1 = result.invoiceTBL.CustomerTBL.phone1,
                            //phone2 = result.invoiceTBL.CustomerTBL.phone2,
                            //deliveryID = result.deliveryID,
                            //invoiceID = result.invoiceID,
                            //start_date = result.start_date,
                            //end_date = result.end_date,
                            //firstItemdate = result.firstItemAvailableDate,
                            //lastItemDate = result.lastItemAvailableDate,
                            //ServicesCount = result.invoiceTBL.DeliveryServiceTBLs.Count,
                            status = result.statusID,
                            //statusName = result.DeliveryStatusTBL.name,
                            //totalCustodycost = result.invoiceTBL.custodyTBL.amount != null ? result.invoiceTBL.custodyTBL.amount : null,
                            //totalcost = result.invoiceTBL.totalcost,

                        };
                    }
                    catch (Exception e) {

                        var a = e;
                    }
                    
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
                    stateName = s.active == true ? "مقفلة" : "مفتوحة",




                }).ToList().OrderByDescending(o => o.custodyID);

                return new ObservableCollection<CustodyDTO>(result);
            }
        }

        async public Task<ObservableCollection<CustodyDTO>> GetCustodyByState(bool state) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.custodyTBLs.Where(w => w.active == state).Select(s => new CustodyDTO() {
                    actve = s.active,
                    amount = s.amount,
                    custodyID = s.custodyID,
                    deliveryID = s.invoiceTBL.deliveryID,
                    invoiceID = s.invoiceID,
                    ownerID = s.ownerID,
                    ownerName = s.EmployeeTBL.name,
                    giverName = s.invoiceTBL.UserTBL.EmployeeTBL.name,
                    stateName = s.active == true ? "مقفلة" : "مفتوحة",




                }).ToList().OrderByDescending(o => o.custodyID);

                return new ObservableCollection<CustodyDTO>(result);
            }
        }

        async public Task<ObservableCollection<CustodyDTO>> GetCustodyByInvoice(int InvoiceID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.custodyTBLs.Where(w => w.invoiceID == InvoiceID).Select(s => new CustodyDTO() {
                    actve = s.active,
                    amount = s.amount,
                    custodyID = s.custodyID,
                    deliveryID = s.invoiceTBL.deliveryID,
                    invoiceID = s.invoiceID,
                    ownerID = s.ownerID,
                    ownerName = s.EmployeeTBL.name,
                    giverName = s.invoiceTBL.UserTBL.EmployeeTBL.name,
                    stateName = s.active == true ? "مقفلة" : "مفتوحة",




                }).ToList().OrderByDescending(o => o.custodyID);

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
                        stateName = result.active == true ? "مقفلة" : "مفتوحة",





                    };
                };

                return new CustodyDTO() { };



            }
        }

        async public Task<bool> AddQuickDeliveryService(int invoiceID, string customerName, int phone, string cityname, string customerAddress, string categoreName, string Destination, bool isFullTrip , decimal deliveryPrice, decimal ProductPrice) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.QuickDeliveryServiceTBLs.Add(new QuickDeliveryServiceTBL() {
                        invoiceID = invoiceID,
                        customerName = customerName,
                        customerPhone = phone,
                        cityName = cityname,
                        customerAddress = customerAddress,
                        categoryName = categoreName,
                        distination = Destination,
                        isFullTrip = isFullTrip,
                        deliveryPrice = deliveryPrice,
                        productPrice = ProductPrice,
                        
                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e) {
                var t = e.Message;
            }
            return false;
        }

        async public Task<InvoiceDTO> GetQuickDeliveryInvoiceByID(int InvoiceID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.QuickDeliveryServiceTBLs.SingleOrDefault(w => w.invoiceID == InvoiceID);

                if (result != null) {
                    return new InvoiceDTO() {
                        invoiceID = result.invoiceID,
                        dateTime = result.invoiceTBL.time,
                        customername = result.customerName,
                        phone1 = result.customerPhone.ToString(),
                        phone2 = "",
                        customerCityname = result.cityName,
                        customerAddress = result.customerAddress,
                        DriverID = result.invoiceTBL.deliveryTBL.driverID,
                        DriverName = result.invoiceTBL.deliveryTBL.EmployeeTBL.name,
                        issuerName = result.invoiceTBL.UserTBL.EmployeeTBL.name,
                        totalafter = (decimal)result.invoiceTBL.totalcost,
                        discount = (decimal)result.invoiceTBL.discount,
                        totalBefore = (decimal)result.productPrice + (decimal)result.deliveryPrice,

                    };
                };
                return new InvoiceDTO() { };
            }
        }

        async public Task<ObservableCollection<DeliveryServiceDTO>> GetQuickDeliveryServiceByID(int InvoiceID) {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.QuickDeliveryServiceTBLs.SingleOrDefault(w => w.invoiceID == InvoiceID);
                if (result != null) {
                    var temp = new ObservableCollection<DeliveryServiceDTO>();

                    temp.Add(new DeliveryServiceDTO() {
                        CategoryName = result.categoryName,
                        Customername = result.customerName,
                        VendorName = result.distination,
                        isFulTrip = (bool)result.isFullTrip,
                        isFulTripName = (result.isFullTrip == true) ? "كاملة" : "نصف",
                        productPrice = result.productPrice,
                        deliveryPrice = (decimal)result.deliveryPrice,
                        InvoiceID = result.invoiceID,
                        status = false,
                    });

                    return temp;
                };
                return new ObservableCollection<DeliveryServiceDTO>();
            }
        }
    }
}
