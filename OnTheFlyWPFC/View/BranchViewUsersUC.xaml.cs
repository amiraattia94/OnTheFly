using OnTheFlyWPFC.ViewModel;
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

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for BranchViewUsersUC.xaml
    /// </summary>
    public partial class BranchViewUsersUC : UserControl
    {

        BranchViewModel branchViewModel;
        EmployeeViewModel employeeViewModel;
        public BranchViewUsersUC()
        {
            InitializeComponent();
            branchViewModel = new BranchViewModel();
            employeeViewModel = new EmployeeViewModel();
        }



        private void BtnSearchUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CmbBranches_Loaded(object sender, RoutedEventArgs e) {
            branchViewModel.GetAllBranches();
            cmbBranches.ItemsSource = branchViewModel.ViewBranch;
            cmbBranches.SelectedValuePath = "branchID";
            cmbBranches.DisplayMemberPath = "branch_name";

        }

        private void CmbBranches_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            employeeViewModel.GetEmployeeByBranch((int)cmbBranches.SelectedValue);
            lstviewemp.ItemsSource = employeeViewModel.ViewEmployees;

        }

        private void Lstviewemp_Loaded(object sender, RoutedEventArgs e) {
            employeeViewModel.GetAllEmployees();
            lstviewemp.ItemsSource = employeeViewModel.ViewEmployees;
        }
    }
}
