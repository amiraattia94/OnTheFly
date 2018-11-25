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
using OnTheFlyWPFC.Model;
using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for HRJobDescriptionUC.xaml
    /// </summary>
    public partial class HRJobDescriptionUC : UserControl
    {
        JobsViewModel jobViewModel;

        public delegate void RefreshList();
        public event RefreshList RefreshListEvent;

        private void RefreshListView()
        {
            jobViewModel.getAllJobs();
            lstViewJobs.ItemsSource = jobViewModel.ViewJob;
            lstViewJobs.Items.Refresh();


        }
        public HRJobDescriptionUC()
        {
            jobViewModel = new JobsViewModel();
            InitializeComponent();
        }

        private void lstViewJobs_Loaded(object sender, RoutedEventArgs e)
        {
            jobViewModel.getAllJobs();
            lstViewJobs.ItemsSource = jobViewModel.ViewJob;            
        }

        private void EditJob(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as JobsDTO;
            HelperClass.JobID = a.jobID;
            // CHANGE CODE HERE BAKA
            var newwindow = new HRJobDescriptionEditMiniWindow();
            RefreshListEvent += new RefreshList(RefreshListView);
            newwindow.UpdateMainList = RefreshListEvent;

            newwindow.ShowDialog();
            RefreshListView();

        }

        private async void DeleteJob(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var a = button.CommandParameter as JobsDTO;
            HelperClass.JobID = a.jobID;
            MessageBox.Show("DELETE IS INVOKED");
            if (await jobViewModel.DeleteJobByID(a.jobID))
                MessageBox.Show("تم المسح بنجاح");
            RefreshListView();
        }

        private void btnAddJob_Click(object sender, RoutedEventArgs e)
        {
            var newwindow = new HRJobDescriptionAddMiniWindow();
            newwindow.ShowDialog();
            RefreshListView();
        }
    }
}
