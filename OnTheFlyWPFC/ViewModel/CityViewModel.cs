using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel {
    public class CityViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private CityService _cityService;
        public List<string> CN { get; private set; }
        public CityDTO cityDTO { get; set; }

        private ObservableCollection<CityDTO> _cityName;
        public ObservableCollection<CityDTO> CityName {
            get {
                return _cityName;
            }

            set {
                _cityName = value;
            }
        }

        private CityDTO _selectedCity;
        public CityDTO SelectedCity {
            get {
                return _selectedCity;
            }

            set {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        

        public CityViewModel() {
            _cityName = new ObservableCollection<CityDTO>();
            _cityService = new CityService();
            cityDTO = new CityDTO();

        }
        
        async public void GetAllCities() {
            
            var cities = await _cityService.GetCity();
            CN = new List<string>();
            foreach(var city in cities) {
                _cityName.Add(city);
                CN.Add(city.name);
            }
        }

        async public Task<bool> DeleteCityCode(string code)
        {
            return await _cityService.DeleteCityByCode(code);
        }

        async public void GetAllTheCities()
        {
            _cityName = await _cityService.GetAllCities();
        }


        async public Task<bool> AddCity(string code, string name)
        {
            return await _cityService.AddCity(code,name);
        }
    

        async public Task<bool> EditCity(string code, string name)
        {
          return await _cityService.EditCityByCode(code, name);
        }
        async public Task<bool> EditCity(string oldcode, string newcode, string name)
        {
            return await _cityService.EditCityByCode(oldcode,newcode, name);
        }

        async public void GetCityByCode(string code)
        {

            cityDTO = await _cityService.GetCityByCode(code);
        }

        async public void GetCityStartByName(string name)
        {
            CityName = await _cityService.GetCityStartByName(name);
        }

        async public void GetCityStartByCode(string code)
        {
            CityName = await _cityService.GetCityStartByCode(code);
        }

        

    }
}
