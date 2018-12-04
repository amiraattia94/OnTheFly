using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System.ComponentModel.DataAnnotations;

namespace OnTheFlyWPFC.ViewModel
{
    public class UsersViewModel 
    {
        UserService _userService;
        public ObservableCollection<UserDTO> viewUser { get; set; }
        public UserDTO editUser { get; set; }

        public UsersViewModel()
        {
            _userService = new UserService();
            viewUser = new ObservableCollection<UserDTO>();
            editUser = new UserDTO();

            GetAllUsers();
        }

        async public Task<bool> AddUser(string username, string password, int employeeID)
        {
            return await _userService.AddUser(username, password, employeeID);
        }

        async public Task<bool> EditUsrByID(int userID, string username, string passeword, int employeeID)
        {
            return await _userService.EditUserByID(userID, username, passeword, employeeID);
        }


        async public Task<bool> DeleteUserByID(int userID)
        {
            return await _userService.DeleteUserByID(userID);
        }


        async public void GetAllUsers()
        {
            viewUser = await _userService.GetAllUser();
        }

        async public void GetUserByID(int userID)
        {
            editUser = await _userService.GetUserByID(userID);
        }

        async public void GetUserByName(string username)
        {
            viewUser = await _userService.GetUserByName(username);
        }

        async public Task<bool> GetUserExists(string user_name, string password)
        {
            return await _userService.GetUserExists(user_name,password);
        }



    }
}
