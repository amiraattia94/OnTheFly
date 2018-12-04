using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel {
    public class DeliveryStatusViewModel {

        public ObservableCollection<DeliveryStatusDTO> allDeliveryStatus { get; set; }

        DeliverlyStatusService deliverlyStatusService;

        public DeliveryStatusViewModel() {
            allDeliveryStatus = new ObservableCollection<DeliveryStatusDTO>();
            deliverlyStatusService = new DeliverlyStatusService();
        }


        async public void GetAllDeliveryStatus() {

            allDeliveryStatus = await deliverlyStatusService.GetAllDeliveryStatus();
        }
    }
}
