using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class DeliveryPricesService {

        async public Task<bool> AddDeliveryPrice(int categoryID,string customerLocation,string vendorLocation, decimal fullTrip,decimal halfTrip, bool status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    con.DeliveryPricesTBLs.Add(new DeliveryPricesTBL() {
                        categoryID = categoryID,
                        customerLocation = customerLocation,
                        vendorLocation = vendorLocation,
                        fullTripPrice = fullTrip,
                        halfTripPrice = halfTrip,
                        status = status,
                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception) {

            }
            return false;
        }

        async public Task<bool> EditDeliveryPrice(int deleveryPriceID, int categoryID, string customerLocation, string vendorLocation, decimal fullTrip, decimal halfTrip, bool status) {
            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var Result = con.DeliveryPricesTBLs.SingleOrDefault(w => w.deliveryPricesID == deleveryPriceID);
                    if (Result != null) {

                        try {
                            Result.categoryID = categoryID;
                            Result.customerLocation = customerLocation;
                            Result.vendorLocation = vendorLocation;
                            Result.fullTripPrice = fullTrip;
                            Result.halfTripPrice = halfTrip;
                            Result.status = status;

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

        async public Task<bool> DeleteDeliveryPriceByID(int deleveryPriceID) {
            await Task.FromResult(true);

            try {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                    var result = con.DeliveryPricesTBLs.SingleOrDefault(w => w.deliveryPricesID == deleveryPriceID);

                    if (result != null) {
                        con.DeliveryPricesTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch {

            }

            return false;

        }

        async public Task<ObservableCollection<DeliveryPriceDTO>> GetAllDeliveryPrice() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryPricesTBLs.Select(s => new DeliveryPriceDTO() {
                    deliveryPriceID = s.deliveryPricesID,
                    categoryID = s.categoryID,
                    categoryName = s.CategoriesTBL.category_name,
                    customerLocation = s.LibyanCitiesTBL.name,
                    customerLocationCode = s.LibyanCitiesTBL.city_code,
                    vendorLocation = s.LibyanCitiesTBL1.name,
                    vendorLocationCode = s.LibyanCitiesTBL1.city_code,
                    fullPrice = s.fullTripPrice,
                    halfPrice = s.halfTripPrice,
                    status = s.status


                }).ToList();

                return new ObservableCollection<DeliveryPriceDTO>(result);
            }

        }

        async public Task<DeliveryPriceDTO> GetDeliveryPriceByID(int PriceID) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryPricesTBLs.SingleOrDefault(w => w.deliveryPricesID == PriceID);

                if (result != null) {
                    return new DeliveryPriceDTO() {
                        deliveryPriceID = result.deliveryPricesID,
                        categoryID = result.categoryID,
                        categoryName = result.CategoriesTBL.category_name,
                        customerLocation = result.LibyanCitiesTBL.name,
                        customerLocationCode = result.LibyanCitiesTBL.city_code,
                        vendorLocation = result.LibyanCitiesTBL1.name,
                        vendorLocationCode = result.LibyanCitiesTBL1.city_code,
                        fullPrice = result.fullTripPrice,
                        halfPrice = result.halfTripPrice,
                        status = result.status

                    };
                };

                return new DeliveryPriceDTO() {};



            }

        }

        async public Task<ObservableCollection<DeliveryPriceDTO>> GetDeliveryPriceByState(bool State) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryPricesTBLs.Where(w => w.status == State).Select(s => new DeliveryPriceDTO() {
                    deliveryPriceID = s.deliveryPricesID,
                    categoryID = s.categoryID,
                    categoryName = s.CategoriesTBL.category_name,
                    customerLocation = s.LibyanCitiesTBL.name,
                    customerLocationCode = s.LibyanCitiesTBL.city_code,
                    vendorLocation = s.LibyanCitiesTBL1.name,
                    vendorLocationCode = s.LibyanCitiesTBL1.city_code,
                    fullPrice = s.fullTripPrice,
                    halfPrice = s.halfTripPrice,
                    status = s.status
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<DeliveryPriceDTO>(result);
                }
                else {
                    return new ObservableCollection<DeliveryPriceDTO>();
                }



            }

        }

        async public Task<ObservableCollection<DeliveryPriceDTO>> GetDeliveryPriceByDeliveryCategory(int deliveryCategory) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryPricesTBLs.Where(w => w.categoryID == deliveryCategory).Select(s => new DeliveryPriceDTO() {
                    deliveryPriceID = s.deliveryPricesID,
                    categoryID = s.categoryID,
                    categoryName = s.CategoriesTBL.category_name,
                    customerLocation = s.LibyanCitiesTBL.name,
                    customerLocationCode = s.LibyanCitiesTBL.city_code,
                    vendorLocation = s.LibyanCitiesTBL1.name,
                    vendorLocationCode = s.LibyanCitiesTBL1.city_code,
                    fullPrice = s.fullTripPrice,
                    halfPrice = s.halfTripPrice,
                    status = s.status
                }).ToList();

                if (result != null) {
                    return new ObservableCollection<DeliveryPriceDTO>(result);
                }
                else {
                    return new ObservableCollection<DeliveryPriceDTO>();
                }



            }

        }



        async public Task<decimal?> GetDeliveryPrice(int category, string vendorLocation , string customerLocation, bool isfulltrip) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryPricesTBLs.SingleOrDefault(w => w.categoryID == category && w.vendorLocation == vendorLocation && w.customerLocation == customerLocation);

                if (result != null) {
                    if (isfulltrip) {
                        return result.fullTripPrice;
                    }
                    else {
                        return result.halfTripPrice;
                    }
                };
             return 0;
            }

        }
    }
}
