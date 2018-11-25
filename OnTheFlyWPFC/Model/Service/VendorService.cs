using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service
{
    class VendorService
    {
        async public Task<ObservableCollection<VendorDTO>> GetVendorByCategoryID(int categoryID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<VendorDTO> result = con.vendorTBLs.Where(w => w.categoryID == categoryID).Select(s => new VendorDTO()
                {
                    VendorCategoryID = (int)s.categoryID,
                    VendorID = s.vendorID,
                    VendorStatus = s.active,
                    VendorName = s.name
                }).ToList();

                return new ObservableCollection<VendorDTO>(result);
            }
        }
    }
}
