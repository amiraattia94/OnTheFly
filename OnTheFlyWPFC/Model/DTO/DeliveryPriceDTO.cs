using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.DTO {
    class DeliveryPriceDTO {
        public int deliveryPriceID { get; set; }
        public int? categoryID { get; set; }
        public string categoryName { get; set; }
        public string customerLocationCode { get; set; }
        public string customerLocation { get; set; }
        public string vendorLocationCode { get; set; }
        public string vendorLocation { get; set; }
        public decimal? fullPrice { get; set; }
        public decimal? halfPrice { get; set; }
        public bool? status { get; set; }
        public string stateName { get; set; }

    }
}
