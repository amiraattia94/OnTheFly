using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System.Collections.ObjectModel;

namespace OnTheFlyWPFC.ViewModel
{
    public class SettingsViewModel
    {
        SettingsService settingsService;
        public ObservableCollection<SettingsDTO> viewSettings { get; set; }
        public SettingsDTO settings { get; set; }

        public SettingsViewModel()
        {
            settingsService = new SettingsService();
            viewSettings = new ObservableCollection<SettingsDTO>();
            settings = new SettingsDTO();

            GetAllSettings();
        }

        async public Task<bool> EditSettingByID(int settingID, string name, decimal value_money, int value_int, string code)
        {
            return await settingsService.EditSettingByID( settingID,  name,  value_money,  value_int,  code);
        }

        async public void GetAllSettings()
        {
            viewSettings = await settingsService.GetAllSettings();
        }

        async public void GetSettingByID(int settingID)
        {
            settings = await settingsService.GetSettingsByID(settingID);
        }

    }
}
