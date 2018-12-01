using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using OnTheFlyWPFC.Model.DTO;

namespace OnTheFlyWPFC.Model.Service
{
    public class SettingsService
    {
        async public Task<bool> EditSettingByID(int settingID, string name, decimal value_money, int value_int, string code)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.SettingsTBLs.SingleOrDefault(w => w.settingID == settingID);
                    if (result != null)
                    {

                        try
                        {
                            result.settingID = settingID;
                            result.name = name;
                            result.value_money = value_money;
                            result.value_int = value_int;
                            result.code = code;
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

        async public Task<ObservableCollection<SettingsDTO>> GetAllSettings()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.SettingsTBLs.Select(s => new SettingsDTO()
                {
                    settingID = s.settingID,
                    name = s.name,
                    value_money = s.value_money,
                    value_int = s.value_int,
                    code = s.code
                }).ToList();

                return new ObservableCollection<SettingsDTO>(result);
            }

        }

        async public Task<SettingsDTO> GetSettingsByID(int settingID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.SettingsTBLs.SingleOrDefault(w => w.settingID == settingID);

                if (result != null)
                {
                    return new SettingsDTO()
                    {
                        settingID = result.settingID,
                        name = result.name,
                        value_money = result.value_money,
                        value_int = result.value_int,
                        code = result.code

                    };
                };

                return new SettingsDTO()
                {
                    settingID = 0,
                    name = "",
                    value_money = 0,
                    value_int = 0,
                    code =""
                };
            }
        }

    }
}
