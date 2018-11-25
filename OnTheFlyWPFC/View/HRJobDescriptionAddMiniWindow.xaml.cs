using OnTheFlyWPFC.Model.DTO;
using OnTheFlyWPFC.Model.Service;
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
using System.Windows.Shapes;

namespace OnTheFlyWPFC.View
{
    /// <summary>
    /// Interaction logic for HRJobDescriptionAddMiniWindow.xaml
    /// </summary>
    public partial class HRJobDescriptionAddMiniWindow : Window
    {
        JobsViewModel _jobsViewModel;

        public HRJobDescriptionAddMiniWindow()
        {
            _jobsViewModel = new JobsViewModel();
            InitializeComponent();
        }

        private async void btnAddJob_Click(object sender, RoutedEventArgs e)
        {
            _jobsViewModel = new JobsViewModel();
            
            if (await _jobsViewModel.AddJob(txtJobName.Text, double.Parse(txtBasicSalary.Text), int.Parse(txtWorkingHoursPerMonth.Text)))
            {
                MessageBox.Show("تم الحفظ");
            }
            else
            {
                MessageBox.Show("حدث خطأ في عملية الحفظ");
            }

            this.Close();
        }

        private void BtnCloseForm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
