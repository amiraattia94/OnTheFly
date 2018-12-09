using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.ComponentModel;

namespace OnTheFlyWPFC.ViewModel
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        UserService _userService;

        public event PropertyChangedEventHandler PropertyChanged;

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
            try
            {
                viewUser = await _userService.GetAllUser();
            }
            catch( Exception)
            {
                MessageBox.Show("عفواَ، هناك خطأ في الإتصال بقاعدة البيانات" ,"خطأ",MessageBoxButton.OK);
               
                
            }
            
        }

        async public void GetUserByID(int userID)
        {
            editUser = await _userService.GetUserByID(userID);
        }

        async public void GetUserByName(string username)
        {
            editUser = await _userService.GetUserByName(username);
        }

        async public Task<bool> GetUserExists(string user_name, string password)
        {
            return await _userService.GetUserExists(user_name,password);
        }

        async public void GetLastUser()
        {
            editUser = await _userService.GetLastUser();
        }


    }
}
