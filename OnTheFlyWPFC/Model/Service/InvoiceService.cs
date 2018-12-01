using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class InvoiceService {

        async public void AddNewInvoice() {
            await Task.FromResult(true);
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.InvoiceTBLs.Add(new InvoiceTBL() {

                        invoiceID = await GetInvoiceID(),
                        time = DateTime.Now,
                        issued = false


                    });
                    await con.SaveChangesAsync();
                    
                }
            }
            catch (Exception) {

            }
            
        }

        //async public Task<int> AddInvoice(int issuerID,int custodyID,int customerID) {
        //    await Task.FromResult(true);
        //    using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
        //        con.invoiceTBLs.Add(new invoiceTBL() {

        //            invoiceID = await GetInvoiceID(),
        //            issuerID = issuerID,
        //            custodyID = custodyID,
        //            customerID = customerID,
        //            time = DateTime.Now,

                    

        //        });
        //    }
        //}

        async public Task<int> GetInvoiceID() {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                int r = 0;
                try {
                    var result = con.InvoiceTBLs.OrderByDescending(w => w.invoiceID).First();
                    if (result != null) {
                        if (result.issued == false) {
                            return result.invoiceID;
                        }
                        else {
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
                var result = con.DeliveryServiceTBLs.Select(s => new DeliveryServiceDTO() {
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

    }
}
