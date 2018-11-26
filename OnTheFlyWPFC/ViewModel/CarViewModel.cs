using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheFlyWPFC.ViewModel {
    class CarViewModel {

        CarService carService;
        public ObservableCollection<CarDTO> ViewCars { get; set; }
        public ObservableCollection<CarTypeDTO> ViewCarType { get; set; }
        public CarDTO car { get; set; }
        public CarTypeDTO cartype { get; set; }

        public CarViewModel() {

            carService = new CarService();
            ViewCars = new ObservableCollection<CarDTO>();
            ViewCarType = new ObservableCollection<CarTypeDTO>();
            car = new CarDTO();
            cartype = new CarTypeDTO();


        }

        async public Task<bool> AddCar(int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status) {
            return await carService.AddCar(Type, Plate, Company, Model, Year, Branch, Status);
        }

        async public Task<bool> EditCarID(int CarID,int Type, string Plate, string Company, string Model, int Year, int Branch, bool Status) {
            return await carService.EditCarID(CarID, Type, Plate, Company, Model, Year, Branch, Status);
        }

        async public Task<bool> DeleteCarByID(int CarID) {
            return await carService.DeleteCarByID(CarID);
        }

        async public void GetAllCars() {
            ViewCars = await carService.GetAllCars();
        }

        async public void GetCarByID(int CarID) {
            car = await carService.GetCarByID(CarID);
        }

        async public void GetCarByPlate(string Plate) {
            ViewCars = await carService.GetCarByPlate(Plate);
        }

        async public void GetCarByType(int Type) {
            ViewCars = await carService.GetCarByType(Type);
        }

        async public void GetAllCarsType() {
            ViewCarType = await carService.GetAllCarsType();
        }

    }
}
