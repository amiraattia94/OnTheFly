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
    /// Interaction logic for HREmployeeEditMiniWindow.xaml
    /// </summary>
    public partial class HREmployeeEditMiniWindow : Window
    {
        public Delegate UpdateMainList;
        EmployeeViewModel _employeeViewModel;
        BranchViewModel branchViewModel;
        JobsViewModel jobViewModel;
        CityViewModel cityViewModel;
        public HREmployeeEditMiniWindow()
        {
            InitializeComponent();
            branchViewModel = new BranchViewModel();
            jobViewModel = new JobsViewModel();
            cityViewModel = new CityViewModel();
            _employeeViewModel = new EmployeeViewModel();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void cmbEmployeeCity_Loaded(object sender, RoutedEventArgs e)
        {
            cityViewModel.GetAllCities();
            cmbEmployeeCity.ItemsSource = cityViewModel.CityName;
            cmbEmployeeCity.DisplayMemberPath = "name";
            //cmbEmployeeCity.Items.SelectedItem=_employeeViewModel.employee.cityID;
            foreach (CityDTO city in cmbEmployeeCity.Items)
            {
                if (city.cityCode == _employeeViewModel.employee.cityID)
                {
                    cmbEmployeeCity.SelectedValue = city;
                    break;
                }
            }
        }

        private void cmbEmployeeJob_Loaded(object sender, RoutedEventArgs e)
        {
            jobViewModel.getAllJobs();
            cmbEmployeeJob.ItemsSource = jobViewModel.ViewJob;
            cmbEmployeeJob.DisplayMemberPath = "job_name";
            foreach (JobsDTO job in cmbEmployeeJob.Items)
            {
                if (job.jobID == _employeeViewModel.employee.jobID)
                {
                    cmbEmployeeJob.SelectedValue = job;
                    break;
                }
            }
        }

        private void cmbEmployeeBranch_Loaded(object sender, RoutedEventArgs e)
        {
            branchViewModel.GetAllBranches();
            cmbEmployeeBranch.ItemsSource = branchViewModel.ViewBranch;
            cmbEmployeeBranch.DisplayMemberPath = "branch_name";
            foreach (BranchDTO branch in cmbEmployeeBranch.Items)
            {
                if (branch.branchID == _employeeViewModel.employee.branchID)
                {
                    cmbEmployeeBranch.SelectedValue = branch;
                    break;
                }
            }
        }

        private async void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            _employeeViewModel = new EmployeeViewModel();
            var city = (CityDTO)cmbEmployeeCity.SelectedValue;
            bool active = HelperClass.TrueOrFalse(cmbEmployeeActive.SelectedIndex.ToString());
            var job = (JobsDTO)cmbEmployeeJob.SelectedValue;
            var branch = (BranchDTO)cmbEmployeeBranch.SelectedValue;
            if (await _employeeViewModel.EditEmployee(HelperClass.employeeID,txtEmployeeName.Text, txtPhone1.Text, txtPhone2.Text, txtAddress.Text, active, job.jobID, city.cityCode, datePickerStartDate.DisplayDate, datePickerEndDate.DisplayDate, branch.branchID))
            {
                MessageBox.Show("تم الحفظ");
                UpdateMainList.DynamicInvoke();
                this.Close();

            }
        }

        private void StkEditEmployee_Loaded(object sender, RoutedEventArgs e)
        {
            _employeeViewModel.GetEmployeeByID(HelperClass.employeeID);
            StkEditEmployee.DataContext = _employeeViewModel.employee;
        }
    }
}
