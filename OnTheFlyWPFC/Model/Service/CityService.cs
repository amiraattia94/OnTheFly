using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.Model.Service {
    public class CityService {
        async public Task<List<CityDTO>> GetCity() {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                List<CityDTO> result = con.LibyanCitiesTBLs.Select(s => new CityDTO() {
                    cityCode = s.city_code,
                    name = s.name
                }).ToList();

                return result;
            }
        }
    }
}
