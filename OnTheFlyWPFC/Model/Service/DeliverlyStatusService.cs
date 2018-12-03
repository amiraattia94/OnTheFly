using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    class DeliverlyStatusService {
        async public Task<ObservableCollection<DeliveryStatusDTO>> GetAllDeliveryStatus() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.DeliveryStatusTBLs.Select(s => new DeliveryStatusDTO() {
                    name = s.name,
                    statusID = s.statusID,


                }).ToList();

                return new ObservableCollection<DeliveryStatusDTO>(result);
            }

        }
    }
}
