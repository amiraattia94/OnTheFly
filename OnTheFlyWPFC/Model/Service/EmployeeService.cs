﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;

namespace OnTheFlyWPFC.Model.Service
{
    public class EmployeeService
    {
        async public Task<bool> AddEmployee(string name, string phone1, string phone2, string address, bool active, int jobID, string cityID, DateTime start_date, DateTime end_date, int branchID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.EmployeeTBLs.Add(new EmployeeTBL()
                    {
                        name = name,
                        phone1 = phone1,
                        phone2 = phone2,
                        address = address,
                        active = active,
                        jobID = jobID,
                        cityID = cityID,
                        start_date = start_date,
                        end_date = end_date,
                        branchID = branchID

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

        async public Task<bool> EditEmployeeByID(int employeeID, string name, string phone1, string phone2, string address, bool active, int jobID, string cityID, DateTime start_date, DateTime? end_date, int branchID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.EmployeeTBLs.SingleOrDefault(w => w.employeeID == employeeID);
                    if (Result != null)
                    {

                        try
                        {
                            Result.name = name;
                            Result.phone1 = phone1;
                            Result.phone2 = phone2;
                            Result.address = address;
                            Result.active = active;
                            Result.jobID = jobID;
                            Result.cityID = cityID;
                            Result.start_date = start_date;
                            Result.end_date = end_date;
                            Result.branchID = branchID;
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

        async public Task<ObservableCollection<EmployeeDTO>> GetAllEmployees()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.EmployeeTBLs.Select(s => new EmployeeDTO()
                {
                    name = s.name,
                    phone1 =s.phone1,
                    phone2 = s.phone2,
                    address = s.address,
                    active = s.active,
                    jobID = s.jobID,
                    cityID = s.cityID,
                    start_date = s.start_date,
                    end_date = s.end_date,
                    branchID = s.branchID
                }).ToList();

                return new ObservableCollection<EmployeeDTO>(result);
            }

        }

        async public Task<bool> DeleteEmployeeByID(int employeeID)
        {
            await Task.FromResult(true);

            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.EmployeeTBLs.SingleOrDefault(w => w.employeeID == employeeID);

                    if (result != null)
                    {
                        con.EmployeeTBLs.Remove(result);
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

        async public Task<EmployeeDTO> GetEmployeeByID(int employeeID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.EmployeeTBLs.SingleOrDefault(w => w.employeeID == employeeID);

                if (result != null)
                {
                    return new EmployeeDTO()
                    {
                        name = result.name,
                        phone1 = result.phone1,
                        phone2 = result.phone2,
                        address = result.address,
                        active = result.active,
                        jobID = result.jobID,
                        cityID = result.cityID,
                        start_date = result.start_date,
                        end_date = result.end_date,
                        branchID = result.branchID
                    };
                };

                return new EmployeeDTO()
                {
                    name = "",
                    phone1 = "",
                    phone2 = "",
                    address = "",
                    active = false,
                    jobID = 0,
                    cityID ="",
                    start_date = DateTime.Today,
                    end_date = null,
                    branchID = null
                };
            }
        }

        async public Task<ObservableCollection<EmployeeDTO>> GetEmployeeByName(string employeeName)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.EmployeeTBLs.Where(w => w.name.StartsWith(employeeName)).Select(s => new EmployeeDTO()
                {
                    name = s.name,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    address = s.address,
                    active = s.active,
                    jobID = s.jobID,
                    cityID = s.cityID,
                    start_date = s.start_date,
                    end_date = s.end_date,
                    branchID = s.branchID
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<EmployeeDTO>(result);
                }
                else
                {
                    return new ObservableCollection<EmployeeDTO>();
                }
            }

        }

        async public Task<ObservableCollection<EmployeeDTO>> GetEmployeeByJobID(int jobID)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.EmployeeTBLs.Where(w => w.jobID == jobID).Select(s => new EmployeeDTO()
                {
                    employeeID= s.employeeID,
                    name = s.name,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    address = s.address,
                    active = s.active,
                    jobID = s.jobID,
                    cityID = s.cityID,
                    start_date = s.start_date,
                    end_date = s.end_date,
                    branchID = s.branchID

                }).ToList();


                if (result != null)
                {
                    return new ObservableCollection<EmployeeDTO>(result);
                }
                else
                {
                    return new ObservableCollection<EmployeeDTO>();
                }
            }
        }

        async public Task<ObservableCollection<EmployeeDTO>> GetEmployeeByCity(string city)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.EmployeeTBLs.Where(w => w.cityID == city).Select(s => new EmployeeDTO()
                {
                    employeeID = s.employeeID,
                    name = s.name,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    address = s.address,
                    active = s.active,
                    jobID = s.jobID,
                    cityID = s.cityID,
                    start_date = s.start_date,
                    end_date = s.end_date,
                    branchID = s.branchID
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<EmployeeDTO>(result);
                }
                else
                {
                    return new ObservableCollection<EmployeeDTO>();
                }



            }

        }

        async public Task<ObservableCollection<EmployeeDTO>> GetEmployeeByAddress(string address)
        {
            await Task.FromResult(true);
            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {

                var result = con.EmployeeTBLs.Where(w => w.address.StartsWith(address)).Select(s => new EmployeeDTO()
                {
                    name = s.name,
                    phone1 = s.phone1,
                    phone2 = s.phone2,
                    address = s.address,
                    active = s.active,
                    jobID = s.jobID,
                    cityID = s.cityID,
                    start_date = s.start_date,
                    end_date = s.end_date,
                    branchID = s.branchID
                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<EmployeeDTO>(result);
                }
                else
                {
                    return new ObservableCollection<EmployeeDTO>();
                }
            }

        }

    }

}