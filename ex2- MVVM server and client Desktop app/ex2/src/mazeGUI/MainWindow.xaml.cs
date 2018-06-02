using MazeGUI.MultiGame;
using MazeGUI.SingleGame;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnSingle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerDetails win = new SinglePlayerDetails();
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnMulti control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            MultiPlayerDetails win = new MultiPlayerDetails();
            win.Show();
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings.Settings win = new Settings.Settings();
            win.Show();
            this.Close();
        }
    }
}
