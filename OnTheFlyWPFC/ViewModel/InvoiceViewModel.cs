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
        

        //public InvoiceDTO invoice { get; set; }
        public int invoiceNewID { get; set; }

        public ObservableCollection<DeliveryServiceDTO> allDeliveryService { get; set; }
        public ObservableCollection<DeliveryServiceDTO2> allDeliveryService2 { get; set; }
        public ObservableCollection<DeliveryDTO> allDelivery { get; set; }
        public ObservableCollection<CustodyDTO> allCustody { get; set; }
        public ObservableCollection<InvoiceDTO> allInvoice { get; set; }

        public DeliveryServiceDTO deliveryService { get; set; }
        public DeliveryDTO Delivery { get; set; }
        public CustodyDTO Custody { get; set; }
        public InvoiceDTO Invoice { get; set; }

        public decimal? totalPrice { get; set; }
        public decimal? productPrice { get; set; }
        public decimal? deliveryPrice { get; set; }

        public InvoiceViewModel() {

            //invoice = new InvoiceDTO();
            invoiceService = new InvoiceService();

            allDeliveryService = new ObservableCollection<DeliveryServiceDTO>();
            allDelivery = new ObservableCollection<DeliveryDTO>();
            allCustody = new ObservableCollection<CustodyDTO>();
            allInvoice = new ObservableCollection<InvoiceDTO>();


            deliveryService = new DeliveryServiceDTO();
            Delivery = new DeliveryDTO();
            Custody = new CustodyDTO();
            Invoice = new InvoiceDTO();
        }

        async public Task<bool> AddInvoice(int issuerID, int customerID, decimal discount,int deliveryID,decimal totalcost,decimal totalDeliveryPrice ,int? custodyID = null) {
           return await invoiceService.AddInvoice(issuerID, customerID, discount, deliveryID, totalcost, totalDeliveryPrice, custodyID);
        }

        async public void GetAllInvoice() {
            allInvoice = await invoiceService.GetAllInvoice();
        }

        async public void GetInvoiceByID(int invoiceID) {
            Invoice = await invoiceService.GetInvoiceByID(invoiceID);
        }

        async public void GetNewInvoiceID() {
            invoiceNewID = await invoiceService.GetInvoiceID();
        }

        async public void GetTotalPriceByInvoiceID(int invoiceID) {
            totalPrice = await invoiceService.GetTotalPriceByInvoiceID(invoiceID);
        }

        async public void GetTotalDeliveryPriceByInvoiceID(int invoiceID) {
            deliveryPrice = await invoiceService.GetTotalDeliveryPriceByInvoiceID(invoiceID);
        }

        async public Task<DateTime?> GetLastDeliveryItemDateByInvoiceID(int invoiceID) {
            return await invoiceService.GetLastDeliveryItemDateByInvoiceID(invoiceID);
        }

        async public Task<DateTime?> GetFirstDeliveryItemDateByInvoiceID(int invoiceID) {
            return await invoiceService.GetFirstDeliveryItemDateByInvoiceID(invoiceID);
        }

        async public Task<bool> DeleteInvoiceByID( int invoiceID)
        {
            return await invoiceService.DeleteInvoiceByID(invoiceID);
        }

        async public Task<bool> AddDeliveryService(int invoiceID, int categoreID, int vendorBranchID, int customerID, bool isFullTrip, decimal productPrice, decimal deliveryPrice, bool status, DateTime avilable) {
            return await invoiceService.AddDeliveryService(invoiceID, categoreID, vendorBranchID, customerID, isFullTrip, productPrice, deliveryPrice, status, avilable);
        }

        async public Task<bool> EditDeliveryService(int deliveryServiceID, int invoiceID, int categoreID, int vendorBranchID, int customerID, bool isFullTrip, decimal productPrice, decimal deliveryPrice, bool status, DateTime avilable) {
            return await invoiceService.EditDeliveryService(deliveryServiceID, invoiceID, categoreID, vendorBranchID, customerID, isFullTrip, productPrice, deliveryPrice, status, avilable);
        }

        async public Task<bool> DeleteDeliveryServiceByID(int deliveryServiceID) {
            return await invoiceService.DeleteDeliveryServiceByID(deliveryServiceID);
        }

        public void DeleteAllDeliveryServiceByinvoice(int invoiceID) {
            invoiceService.DeleteAllDeliveryServiceByinvoice(invoiceID);
        }

        async public void GetAllDeliveryServices() {
            allDeliveryService = await invoiceService.GetAllDeliveryServices();
        }

        async public void GetAllDeliveryServicesByInvoice(int invoiceID) {
            allDeliveryService = await invoiceService.GetAllDeliveryServicesByInvoice(invoiceID);
        }

        async public void GetAllDeliveryServicesByInvoice2(int invoiceID) {
            allDeliveryService2 = await invoiceService.GetAllDeliveryServicesByInvoice2(invoiceID);
        }

        async public void GetDeliveryServiceByID(int deliveryServiceID) {
            deliveryService = await invoiceService.GetDeliveryServiceByID(deliveryServiceID);
        }



        async public Task<bool> AddDelivery(int? carID, int driverID, DateTime? startday, DateTime? enddate, int status, DateTime? firstItemDate, DateTime? lastItemDate, int invoiceID) {
            return await invoiceService.AddDelivery( carID,  driverID,   startday,   enddate,  status,  firstItemDate,  lastItemDate, invoiceID);
        }

        async public Task<int> AddDeliveryInt(int? carID, int driverID, DateTime? startday, DateTime? enddate, int status, DateTime? firstItemDate, DateTime? lastItemDate,int invoiceID) {
            return await invoiceService.AddDeliveryInt(carID, driverID, startday, enddate, status, firstItemDate, lastItemDate, invoiceID);
        }

        async public Task<bool> EditDelivery(int deliveryID, DateTime? startday, DateTime? enddate, int status, DateTime? firstItemDate, DateTime? lastItemDate) {
            return await invoiceService.EditDelivery( deliveryID, startday,  enddate,  status,  firstItemDate,  lastItemDate);
        }

        async public Task<bool> EditDelivery(int deliveryID, int status) {
            return await invoiceService.EditDelivery( deliveryID, status);
        }

        async public void GetAllDelivery() {
            allDelivery = await invoiceService.GetAllDelivery();
        }

        async public void GetAllDelivery(int deliveryID) {
            allDelivery = await invoiceService.GetAllDelivery( deliveryID);
        }

        async public void GetAllDeliveryByStatus(int Status) {
            allDelivery = await invoiceService.GetAllDeliveryByStatus(Status);
        }

        async public void GetDeliveryByID(int deliveryID) {
            Delivery = await invoiceService.GetDeliveryByID( deliveryID);
        }



        async public Task<bool> AddCustody(int OwnerID, decimal ammount, bool status, int invoiceID) {
            return await invoiceService.AddCustody( OwnerID,  ammount,  status,  invoiceID);
        }

        async public Task<int> AddCustodyInt(int OwnerID, decimal ammount, bool status, int invoiceID) {
            return await invoiceService.AddCustodyInt(OwnerID, ammount, status, invoiceID);
        }

        async public Task<bool> EditCustody(int custodyID, bool status) {
            return await invoiceService.EditCustody( custodyID,  status);
        }

        async public Task<bool> DeleteCustody(int custodyID) {
            return await invoiceService.DeleteCustody(custodyID);
        }

        async public void GetAllCustody() {
            allCustody = await invoiceService.GetAllCustody();
        }

        async public void GetCustodyByState(bool state) {
            allCustody = await invoiceService.GetCustodyByState(state);
        }

        async public void GetCustodyByInvoice(int invoiceID) {
            allCustody = await invoiceService.GetCustodyByInvoice(invoiceID);
        }

        async public void GetCustodyByID(int CustodyID) {
            Custody = await invoiceService.GetCustodyByID(CustodyID);
        }

    }
}
