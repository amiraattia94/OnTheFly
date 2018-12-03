using OnTheFlyWPFC.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OnTheFlyWPFC {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        void AppStartup(object sender, StartupEventArgs args) {
            LoginWindow mainWindow = new LoginWindow();
            mainWindow.Show();
        }

    }
}
