using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel {
    class DeliveryPricesViewModel {

        DeliveryPricesService DeliveryPricesService;

        public ObservableCollection<DeliveryPriceDTO> ViewDeliveryPrices { get; set; }
        public DeliveryPriceDTO DeliveryPrice { get; set; }


        public DeliveryPricesViewModel() {
            DeliveryPricesService = new DeliveryPricesService();

            ViewDeliveryPrices = new ObservableCollection<DeliveryPriceDTO>();
            DeliveryPrice = new DeliveryPriceDTO();

            GetAllDeliveryPrice();
        }

        async public Task<bool> AddDeliveryPrice(int categoryID, string customerLocation, string vendorLocation, decimal fullTrip, decimal halfTrip, bool status) {
            return await DeliveryPricesService.AddDeliveryPrice(categoryID, customerLocation, vendorLocation, fullTrip, halfTrip, status);
        }

        async public Task<bool> EditDeliveryPrice(int deleveryPriceID, int categoryID, string customerLocation, string vendorLocation, decimal fullTrip, decimal halfTrip, bool status) {
            return await DeliveryPricesService.EditDeliveryPrice(deleveryPriceID, categoryID, customerLocation, vendorLocation, fullTrip, halfTrip, status);
        }

        async public Task<bool> DeleteDeliveryPriceByID(int deleveryPriceID) {
            return await DeliveryPricesService.DeleteDeliveryPriceByID(deleveryPriceID);
        }

        async public void GetAllDeliveryPrice() {
            ViewDeliveryPrices = await DeliveryPricesService.GetAllDeliveryPrice();
        }

        async public void GetDeliveryPriceByID(int PriceID) {
            DeliveryPrice = await DeliveryPricesService.GetDeliveryPriceByID(PriceID);
        }

        async public void GetDeliveryPriceByState(bool State) {
            ViewDeliveryPrices = await DeliveryPricesService.GetDeliveryPriceByState(State);
        }

        async public void GetDeliveryPriceByDeliveryCategory(int deliveryCategory) {
            ViewDeliveryPrices = await DeliveryPricesService.GetDeliveryPriceByDeliveryCategory(deliveryCategory);
        }


    }
}
