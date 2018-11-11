using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;

namespace OnTheFlyWPFC.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private UserService _userService;
        public List<string> UN { get; private set; }

        private ObservableCollection<UserDTO> _userName;
        public ObservableCollection<UserDTO> UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }

        private UserDTO _selectedUser;
        public UserDTO SelectedUser
        {
            get
            {
                return _selectedUser;
            }

            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }



        public LoginViewModel()
        {
            _userName = new ObservableCollection<UserDTO>();
            _userService = new UserService();


        }

        async public void GetAllCities()
        {
            var users = await _userService.GetUser();
            UN = new List<string>();
            foreach (var user in users)
            {
                _userName.Add(user);
                UN.Add(user.username);
            }
        }
    }
}
