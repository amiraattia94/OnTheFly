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
using System.Windows.Shapes;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
using OnTheFlyWPFC.ViewModel;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for HREmployeeAddMiniWindow.xaml
    /// </summary>
    public partial class HREmployeeAddMiniWindow : Window
    {
        public Delegate UpdateMainList;
        EmployeeViewModel _employeeViewModel;
        BranchViewModel branchViewModel;
        JobsViewModel jobViewModel;
        CityViewModel cityViewModel;
        public HREmployeeAddMiniWindow()
        {
            InitializeComponent();
            branchViewModel = new BranchViewModel();
            jobViewModel = new JobsViewModel();
            cityViewModel = new CityViewModel();
            _employeeViewModel = new EmployeeViewModel();
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void cmbEmployeeBranch_Loaded(object sender, RoutedEventArgs e)
        {
            branchViewModel.GetAllBranches();
            cmbEmployeeBranch.ItemsSource = branchViewModel.ViewBranch;
            cmbEmployeeBranch.DisplayMemberPath = "branch_name";
        }

        private void cmbEmployeeJob_Loaded(object sender, RoutedEventArgs e)
        {
            jobViewModel.getAllJobs();
            cmbEmployeeJob.ItemsSource = jobViewModel.ViewJob;
            cmbEmployeeJob.DisplayMemberPath = "job_name";
        }

        private void cmbEmployeeCity_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewModel.GetAllCities();
            cmbEmployeeCity.ItemsSource = cityViewModel.CityName;
            cmbEmployeeCity.DisplayMemberPath = "name";
        }

        private async void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            _employeeViewModel = new EmployeeViewModel();
            var city = (CityDTO)cmbEmployeeCity.SelectedValue;
           
            var job = (JobsDTO)cmbEmployeeJob.SelectedValue;
            var branch = (BranchDTO)cmbEmployeeBranch.SelectedValue;
            if (await _employeeViewModel.AddEmployee(txtEmployeeName.Text,txtPhone1.Text,txtPhone2.Text,txtAddress.Text,true,job.jobID,city.cityCode, (DateTime)datePickerStartDate.SelectedDate, DateTime.Now,branch.branchID))
            {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }
        }
    }
}
