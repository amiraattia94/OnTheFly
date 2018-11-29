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
    /// Interaction logic for HRViewUC.xaml
    /// </summary>
    public partial class HRViewUC : UserControl
    {
        EmployeeViewModel employeeViewModel;
        JobsViewModel jobViewModel;
        CityViewModel cityViewModel;
        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        private void RefreshListView()
        {
            employeeViewModel.GetAllEmployees();
            lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
            lstviewEmployees.Items.Refresh();
        }
        public HRViewUC()
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel();
            jobViewModel = new JobsViewModel();
            cityViewModel = new CityViewModel();
           

        }
       

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new HREmployeeAddMiniWindow();


            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
        }

        private void BtnSearchHR_Click(object sender, RoutedEventArgs e)
        {
            employeeViewModel.GetEmployeeByName(TxtSearchEmployeeName.Text);
            lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
            lstviewEmployees.Items.Refresh();
            cmbEmployeeCity.SelectedIndex = -1;
            cmbEmployeeState.SelectedIndex = -1;
        }

        private void lstviewEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            employeeViewModel.GetAllEmployees();
            lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
        }

        private async void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as EmployeeDTO;
            HelperClass.employeeID = a.employeeID;

            if (await employeeViewModel.DeleteCustomerByID(a.employeeID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();
        }

        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as EmployeeDTO;
            HelperClass.employeeID = a.employeeID;

            var newwindow = new HREmployeeEditMiniWindow();

            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.Show();


        }

        private void cmbEmployeeCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEmployeeCity.SelectedIndex != -1)
            {
                var selectedcity = (CityDTO)cmbEmployeeCity.SelectedItem;
                employeeViewModel.GetEmployeeByCity(selectedcity.cityCode);
                lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
                lstviewEmployees.Items.Refresh();
                cmbEmployeeJob.SelectedIndex = -1;
                cmbEmployeeState.SelectedIndex = -1;

                TxtSearchEmployeeName.Text = "";
            }
        }

        private void cmbEmployeeCity_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewModel.GetAllCities();
            cmbEmployeeCity.ItemsSource = cityViewModel.CityName;
            cmbEmployeeCity.DisplayMemberPath = "name";
        }

        private void TxtSearchEmployeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            employeeViewModel.GetEmployeeByName(TxtSearchEmployeeName.Text);
            lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
            lstviewEmployees.Items.Refresh();
            cmbEmployeeCity.SelectedIndex = -1;
            cmbEmployeeState.SelectedIndex = -1;
        }

        private void cmbEmployeeState_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmbEmployeeState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEmployeeState.SelectedIndex != -1)
            {
                
                bool active = HelperClass.TrueOrFalse(cmbEmployeeState.SelectedIndex.ToString());
                employeeViewModel.GetEmployeeByActive(active);
                lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
                lstviewEmployees.Items.Refresh();
                cmbEmployeeCity.SelectedIndex = -1;
                cmbEmployeeJob.SelectedIndex = -1;
                TxtSearchEmployeeName.Text = "";
            }
        }

        private void cmbEmployeeJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEmployeeJob.SelectedIndex != -1)
            {
                var selectedjobs = (JobsDTO)cmbEmployeeJob.SelectedItem;
                employeeViewModel.GetEmployeeByJobID(selectedjobs.jobID);
                lstviewEmployees.ItemsSource = employeeViewModel.ViewEmployees;
                lstviewEmployees.Items.Refresh();
                
                cmbEmployeeCity.SelectedIndex = -1;
                cmbEmployeeState.SelectedIndex = -1;
                TxtSearchEmployeeName.Text = "";
            }
        }

        private void cmbEmployeeJobs_Loaded(object sender, RoutedEventArgs e)
        {
            jobViewModel.getAllJobs();
            cmbEmployeeJob.ItemsSource = jobViewModel.ViewJob;
            cmbEmployeeJob.DisplayMemberPath = "job_name";
        }
    }
}
