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
using OnTheFlyWPFC.ViewModel;
using OnTheFlyWPFC.Model;
using OnTheFlyWPFC.Model.Service;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for FinancePreferencesUC.xaml
    /// </summary>
    public partial class FinancePreferencesUC : UserControl
    {
        SettingsViewModel settingsViewModel1, settingsViewModel2, settingsViewModel3, settingsViewModel4;        
        UsersViewModel usersViewModel;
        public FinancePreferencesUC()
        {
            settingsViewModel1 = new SettingsViewModel();
            settingsViewModel2 = new SettingsViewModel();
            settingsViewModel3 = new SettingsViewModel();
            settingsViewModel4 = new SettingsViewModel();
            usersViewModel = new UsersViewModel();
            InitializeComponent();
        }

        private void stkEditPreferences_Loaded(object sender, RoutedEventArgs e)
        {
         //   settingsViewModel.GetAllSettings();
          ///  stkEditPreferences.DataContext = settingsViewModel.viewSettings;
            //settingsViewModel.settings.name.n
        }

      
        private void stkEditPreferences1_Loaded(object sender, RoutedEventArgs e)
        {
            settingsViewModel1.GetSettingByID(1);
            stkEditPreferences1.DataContext = settingsViewModel1.settings;
        }

        private async void btnSave1(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.add_finance) {
                if (await settingsViewModel1.EditSettingByID(settingsViewModel1.settings.settingID, settingsViewModel1.settings.name, decimal.Parse(txtValueMoney1.Text), settingsViewModel1.settings.value_int ?? 0, settingsViewModel1.settings.code)) {
                    MessageBox.Show("تم الحفظ");
                    HelperClass.overtimeHourPrice = decimal.Parse(txtValueMoney1.Text);
                }
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

        }

        private async void btnSave2(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.add_finance) {
                if (await settingsViewModel2.EditSettingByID(settingsViewModel2.settings.settingID, settingsViewModel2.settings.name, decimal.Parse(txtValueMoney2.Text), settingsViewModel2.settings.value_int ?? 0, settingsViewModel2.settings.code)) {
                    MessageBox.Show("تم الحفظ");
                    HelperClass.overtimeDayPrice = decimal.Parse(txtValueMoney2.Text);
                }
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }


        }

        private async void btnSave3(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.add_finance) {
                if (await settingsViewModel3.EditSettingByID(settingsViewModel3.settings.settingID, settingsViewModel3.settings.name, decimal.Parse(txtValueMoney3.Text), settingsViewModel3.settings.value_int ?? 0, settingsViewModel3.settings.code)) {
                    MessageBox.Show("تم الحفظ");
                    HelperClass.AbsentDayPrice = decimal.Parse(txtValueMoney3.Text);
                }
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }


        }

        private async void btnSave4(object sender, RoutedEventArgs e)
        {
            if (HelperClass.userGroupRoleDTO.add_finance) {
                if (await settingsViewModel4.EditSettingByID(settingsViewModel4.settings.settingID, settingsViewModel4.settings.name, decimal.Parse(txtValueMoney4.Text), settingsViewModel4.settings.value_int ?? 0, settingsViewModel4.settings.code)) {
                    MessageBox.Show("تم الحفظ");
                    HelperClass.lateHourPrice = decimal.Parse(txtValueMoney4.Text);
                }
            }
            else {
                MessageBox.Show("عذراَ، صلاحيتك لا تسمح بعرض هذه النافذة", "", MessageBoxButton.OK, MessageBoxImage.Stop);
            }


        }

        private void stkEditPreferences2_Loaded(object sender, RoutedEventArgs e)
        {
            settingsViewModel2.GetSettingByID(2);
            stkEditPreferences2.DataContext = settingsViewModel2.settings;
        }

        private void stkEditPreferences3_Loaded(object sender, RoutedEventArgs e)
        {
            settingsViewModel3.GetSettingByID(3);
            stkEditPreferences3.DataContext = settingsViewModel3.settings;
        }

        private void stkEditPreferences4_Loaded(object sender, RoutedEventArgs e)
        {
            settingsViewModel4.GetSettingByID(4);
            stkEditPreferences4.DataContext = settingsViewModel4.settings;
        }
    }
}
