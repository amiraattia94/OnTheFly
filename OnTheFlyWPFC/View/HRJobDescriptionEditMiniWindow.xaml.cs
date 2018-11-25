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
    /// Interaction logic for HRJobDescriptionEditMiniWindow.xaml
    /// </summary>
    public partial class HRJobDescriptionEditMiniWindow : Window
    {
        public Delegate UpdateMainList;
        JobsViewModel jobsViewModel;
        public HRJobDescriptionEditMiniWindow()
        {
            InitializeComponent();
            
            jobsViewModel = new JobsViewModel();
            jobsViewModel.GetJobByID(HelperClass.BranchID);

        }

        private async void btnEditJob_Click(object sender, RoutedEventArgs e)
        {
            jobsViewModel = new JobsViewModel();

            if (await jobsViewModel.EditJobByID(HelperClass.JobID, txtJobName.Text, int.Parse(txtBasicSalary.Text), int.Parse(txtWorkingHoursPerMonth.Text)))
            {
                UpdateMainList.DynamicInvoke();
                MessageBox.Show("تم الحفظ");
           
                this.Close();
            }

        }

        private void btnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StkEditJob_Loaded(object sender, RoutedEventArgs e)
        {
            jobsViewModel.GetJobByID(HelperClass.JobID);
            StkEditJob.DataContext = jobsViewModel.EditJob;
        }
    }
}
