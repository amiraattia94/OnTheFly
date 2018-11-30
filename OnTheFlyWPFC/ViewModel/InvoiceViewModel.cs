using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel {
    class InvoiceViewModel {

        InvoiceService invoiceService;
        

        public InvoiceDTO invoice { get; set; }
        public int invoiceNewID { get; set; }

        public ObservableCollection<DeliveryServiceDTO> allDeliveryService { get; set; }
        public DeliveryServiceDTO deliveryService { get; set; }

        public InvoiceViewModel() {

            invoiceService = new InvoiceService();
            invoice = new InvoiceDTO();
            
        }

        public void AddNewInvoice() {
           invoiceService.AddNewInvoice();
        }

        public void DeleteAllDeliveryServiceByinvoice(int invoiceID) {
            invoiceService.DeleteAllDeliveryServiceByinvoice(invoiceID);
        }

        async public void GetNewInvoiceID() {
            invoiceNewID = await invoiceService.GetInvoiceID();
        }



        async public Task<bool> AddDeliveryService(int invoiceID, int categoreID, int vendorBranchID, int customerID, bool isFullTrip, decimal productPrice, decimal deliveryPrice, bool status, DateTime avilable) {
            return await invoiceService.AddDeliveryService(invoiceID, categoreID, vendorBranchID, customerID, isFullTrip, productPrice, deliveryPrice, status, avilable);
        }

        async public Task<bool> EditDeliveryService(int deliveryServiceID, int invoiceID, int categoreID, int vendorBranchID, int customerID, bool isFullTrip, decimal productPrice, decimal deliveryPrice, bool status, DateTime avilable) {
            return await invoiceService.EditDeliveryService(deliveryServiceID, invoiceID, categoreID, vendorBranchID, customerID, isFullTrip, productPrice, deliveryPrice, status, avilable);
        }

        async public Task<bool> DeleteDeliveryServiceByID(int deliveryServiceID) {
            return await invoiceService.DeleteDeliveryServiceByID( deliveryServiceID);
        }

        async public void GetAllDeliveryServices() {
            allDeliveryService = await invoiceService.GetAllDeliveryServices();
        }

        async public void GetDeliveryServiceByID(int deliveryServiceID) {
            deliveryService = await invoiceService.GetDeliveryServiceByID(deliveryServiceID);
        }

    }
}
