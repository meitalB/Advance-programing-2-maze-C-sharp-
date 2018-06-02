using System.Windows;

namespace MazeGUI.Settings
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        /// <summary>
        /// The vm
        /// </summary>
        private SettingsViewModel vm;


        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            vm = new SettingsViewModel(new ApplicationSettingsModel());
            DataContext = vm;
        }

        /// <summary>
        /// Handles the Click event of the btnCancle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            vm.ReloadSettings();
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {


            vm.SaveSettings();
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
    }
}
