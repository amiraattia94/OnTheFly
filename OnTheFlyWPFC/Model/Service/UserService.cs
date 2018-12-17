using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;

namespace OnTheFlyWPFC.Model.Service
{
    class UserService 
    {
        async public Task<List<UserDTO>> GetUser()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                List<UserDTO> result = con.UserTBLs.Select(s => new UserDTO()
                {
                    UserName = s.user_name,
                    Password = s.password

                }).ToList();

                return result;
            }
        }

        async public Task<UserDTO> GetLoginUserData(string username, string password)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.UserTBLs.SingleOrDefault(u => u.user_name == username && u.password == password);
                if(result != null) {
                    return new UserDTO() {
                        userID = result.userID,
                        UserName = result.user_name,
                        EmployeeID = result.employeeID,
                        EmployeeName = result.EmployeeTBL.name,
                        EmployeeBranchID = result.EmployeeTBL.branchID,
                        EmployeeBranchName = result.EmployeeTBL.CompanyBranchTBL.branch_name
                    };
                }
                
            }
            return new UserDTO() { };

        }

        async public Task<Boolean> GetUserExists(string username, string password) {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities()) {
                var result = con.UserTBLs.SingleOrDefault(u => u.user_name == username && u.password == password);
                if (result != null) {
                    username = result.user_name;
                    password = result.password;
                    return true;

                }
            }
            return false;

        }


        async public Task<bool> AddUser(string username, string password, int employeeID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    con.UserTBLs.Add(new UserTBL()
                    {
                        user_name = username,
                        password = password,
                        employeeID = employeeID
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


        async public Task<bool> EditUserByID(int userID, string username, string password, int employeeID)
        {
            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var Result = con.UserTBLs.SingleOrDefault(w => w.userID == userID);
                    if (Result != null)
                    {

                        try
                        {
                            Result.user_name = username;
                            Result.password = password;
                            Result.employeeID = employeeID;
              
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

        async public Task<ObservableCollection<UserDTO>> GetAllUser()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.UserTBLs.Select(s => new UserDTO()
                {
                    userID = s.userID,
                    UserName = s.user_name,
                    Password = s.password,
                    EmployeeID = s.employeeID,
                    EmployeeName = s.EmployeeTBL.name,
                    EmployeeBranchID = s.EmployeeTBL.branchID,
                    EmployeeBranchName = s.EmployeeTBL.CompanyBranchTBL.branch_name,
                }).ToList();

                return new ObservableCollection<UserDTO>(result);
            }

        }


        async public Task<UserDTO> GetUserByID(int userID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.UserTBLs.SingleOrDefault(w => w.userID == userID);

                if (result != null)
                {
                    return new UserDTO()
                    {
                        userID = result.userID,
                        UserName = result.user_name,
                        Password = result.password,
                        EmployeeID = result.employeeID,
                        EmployeeName = result.EmployeeTBL.name,
                        EmployeeBranchID = result.EmployeeTBL.branchID,
                        EmployeeBranchName = result.EmployeeTBL.CompanyBranchTBL.branch_name,


                    };
                };

                return new UserDTO()
                {
                    userID = 0,
                    UserName = "0",
                    Password = "0",
                    EmployeeID = 0

                };

            }

        }

        async public Task<bool> DeleteUserByID(int userID)
        {
            await Task.FromResult(true);

            try
            {
                using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
                {
                    var result = con.UserTBLs.SingleOrDefault(w => w.userID == userID);

                    if (result != null)
                    {
                        con.UserTBLs.Remove(result);
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

        async public Task<ObservableCollection<UserDTO>> GetUserByEmployee(int employeeID)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.UserTBLs.Where(w => w.employeeID == employeeID).Select(s => new UserDTO()
                {
                    userID = s.userID,
                    UserName = s.user_name,
                    Password = s.password,
                    EmployeeID = s.employeeID,
                    EmployeeName = s.EmployeeTBL.name,
                    EmployeeBranchID = s.EmployeeTBL.branchID,
                    EmployeeBranchName = s.EmployeeTBL.CompanyBranchTBL.branch_name,

                }).ToList();

                if (result != null)
                {
                    return new ObservableCollection<UserDTO>(result);
                }
                else
                {
                    return new ObservableCollection<UserDTO>();
                }



            }

        
            
        }

        async public Task<UserDTO> GetUserByName(string username)
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.UserTBLs.SingleOrDefault(w => w.user_name == username);

                if (result != null)
                {
                    return new UserDTO()
                    {
                        userID = result.userID,
                        UserName = result.user_name,
                        Password = result.password,
                        EmployeeID = result.employeeID,
                        EmployeeName = result.EmployeeTBL.name,
                        EmployeeBranchID = result.EmployeeTBL.branchID,
                        EmployeeBranchName = result.EmployeeTBL.CompanyBranchTBL.branch_name
                        


                    };
                };

                return new UserDTO()
                {
                    userID = 0,
                    UserName = "0",
                    Password = "0",
                    EmployeeID = 0

                };

            }
        }

        async public Task<UserDTO> GetLastUser()
        {
            await Task.FromResult(true);

            using (OnTheFlyDBEntities con = new OnTheFlyDBEntities())
            {
                var result = con.UserTBLs.OrderByDescending(w => w.userID).First();

                if (result != null)
                {
                    return new UserDTO()
                    {
                        userID = result.userID,
                        UserName = result.user_name,
                        Password = result.password,
                        EmployeeID = result.employeeID,
                        EmployeeName = result.EmployeeTBL.name,
                        EmployeeBranchID = result.EmployeeTBL.branchID,
                        EmployeeBranchName = result.EmployeeTBL.CompanyBranchTBL.branch_name,

                    };
                };

                return new UserDTO()
                {
                    userID = 0,
                    UserName = "",
                    Password = "",
                    EmployeeID = 0,
                };
            }
        }

    }
}
