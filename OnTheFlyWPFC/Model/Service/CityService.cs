using OnTheFlyWPFC.Model.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        async public Task<ObservableCollection<CityDTO>> GetAllCities()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<CityDTO> result = con.LibyanCitiesTBLs.Select(s => new CityDTO()
                {
                    cityCode = s.city_code,
                    name = s.name
                }).ToList();

                return new ObservableCollection<CityDTO>(result);
            }
        }

        async public Task<bool> AddCity(string code , string name)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.LibyanCitiesTBLs.Add(new LibyanCitiesTBL()
                    {

                        city_code = code,
                        name = name,

                    });
                    await con.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        async public Task<bool> EditCityByCode(string code, string name)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.LibyanCitiesTBLs.SingleOrDefault(w => w.city_code == code);
                    if (Result != null)
                    {

                        try
                        {

                            Result.name = name;

                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {

                        }
                        return false;
                    }
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        async public Task<bool> EditCityByCode(string old_code, string new_code, string name)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.LibyanCitiesTBLs.SingleOrDefault(w => w.city_code == old_code);
                    if (Result != null)
                    {

                        try
                        {
                            Result.city_code = new_code;
                            Result.name = name;

                            await con.SaveChangesAsync();
                            return true;
                        }
                        catch
                        {

                        }
                        return false;
                    }
                }
            }
            catch (Exception)
            {

            }
            return false;
        }

        async public Task<bool> DeleteCityByCode(string code)
        {
            await Task.FromResult(true);

            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {


                    var result = con.LibyanCitiesTBLs.SingleOrDefault(w => w.city_code == code);

                    if (result != null)
                    {

                        con.LibyanCitiesTBLs.Remove(result);
                        await con.SaveChangesAsync();
                        return true;
                    };

                }
            }
            catch
            {

            }

            return false;

        }

        async public Task<CityDTO> GetCityByCode(string code)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.LibyanCitiesTBLs.SingleOrDefault(w => w.city_code == code);

                if (result != null)
                {
                    return new CityDTO()
                    {
                        cityCode = result.city_code,
                        name = result.name
                        
                    };
                };

                return new CityDTO()
                {
                    cityCode = "",
                    name= ""
                };



            }
        }


        async public Task<ObservableCollection<CityDTO>> GetCityStartByName(string name)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.LibyanCitiesTBLs.Where(w => w.name.StartsWith(name)).Select(s => new CityDTO()
                {
                    cityCode = s.city_code,
                    name = s.name
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<CityDTO>(result);
                }
                else
                {
                    return new ObservableCollection<CityDTO>();
                }
            }

        }
        async public Task<ObservableCollection<CityDTO>> GetCityStartByCode(string code)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.LibyanCitiesTBLs.Where(w => w.city_code.StartsWith(code)).Select(s => new CityDTO()
                {
                    cityCode = s.city_code,
                    name = s.name
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<CityDTO>(result);
                }
                else
                {
                    return new ObservableCollection<CityDTO>();
                }
            }

        }

    }
}
