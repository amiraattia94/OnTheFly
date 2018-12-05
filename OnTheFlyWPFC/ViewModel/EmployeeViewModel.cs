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
    public class EmployeeViewModel
    {
        EmployeeService employeeService;
        public ObservableCollection<EmployeeDTO> ViewEmployees { get; set; }
        public EmployeeDTO employee { get; set; }

        public EmployeeViewModel()
        {
            employeeService = new EmployeeService();
            ViewEmployees = new ObservableCollection<EmployeeDTO>();           
            employee = new EmployeeDTO();
            
            GetAllEmployees();
        }

        async public Task<bool> AddEmployee(string employeeName, string phone1, string phone2, string address, bool active, int jobID, string cityID, DateTime start_date, DateTime end_date, int branchID)
        {
            return await employeeService.AddEmployee(employeeName, phone1, phone2, address, active, jobID, cityID, start_date, end_date, branchID);
        }

        async public Task<bool> EditEmployee(int employeeID, string employeeName, string phone1, string phone2, string address, bool active, int jobID, string cityID, DateTime start_date, DateTime end_date, int branchID)
        {
            return await employeeService.EditEmployeeByID(employeeID, employeeName, phone1, phone2, address, active, jobID, cityID, start_date, end_date, branchID);
        }

        async public Task<bool> DeleteCustomerByID(int employeeID)
        {
            return await employeeService.DeleteEmployeeByID(employeeID);
        }

        async public void GetEmployeeByID(int employeeID)
        {
            employee = await employeeService.GetEmployeeByID(employeeID);
        }

        async public void GetAllEmployees()
        {
            ViewEmployees = await employeeService.GetAllEmployees();
        }

        async public void GetEmployeeByIDs(int[] employeeIDs)
        {
            ViewEmployees = await employeeService.GetEmployeeByIDs(employeeIDs);
        }

        async public void GetEmployeeByCity(string cityCode)
        {
            ViewEmployees = await employeeService.GetEmployeeByCity(cityCode);
        }

        async public void GetEmployeeByName(string employeeName)
        {
            ViewEmployees = await employeeService.GetEmployeeByName(employeeName);
        }

        async public void GetEmployeeByActive(bool active)
        {
            ViewEmployees = await employeeService.GetEmployeeByActive(active);
        }

        async public void GetEmployeeByAddress(string address)
        {
            ViewEmployees = await employeeService.GetEmployeeByAddress(address);
        }

        async public void GetEmployeeByJobID(int jobID)
        {
            ViewEmployees = await employeeService.GetEmployeeByJobID(jobID);
        }


        async public void GetEmployeeByBranch(int branchID) {
            ViewEmployees = await employeeService.GetEmployeeByBranch(branchID);
        }
    }
}
