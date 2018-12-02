using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for SettingsUserGroupRoleUC.xaml
    /// </summary>
    public partial class SettingsUserGroupRoleUC : UserControl
    {
        UserGroupRoleViewModel userGroupRoleViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;
        private void RefreshListView()
        {
            

        }

        public SettingsUserGroupRoleUC()
        {
            userGroupRoleViewModel = new UserGroupRoleViewModel();
            InitializeComponent();
        }

        private void lstViewUserGroupRole_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAdduserGroupRole_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
