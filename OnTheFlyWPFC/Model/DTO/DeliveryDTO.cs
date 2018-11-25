using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO
{
    public class DeliveryDTO
    {
        public int deliveryID { get; set; }
        public bool full_delivery { get; set; }
        public int carID { get; set; }
        public int driverID { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public int status { get; set; }
    }
}
