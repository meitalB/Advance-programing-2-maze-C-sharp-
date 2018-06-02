using MazeLib;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayerDetails.xaml
    /// </summary>
    public partial class MultiPlayerDetails : Window
    {
        /// <summary>
        /// The vm
        /// </summary>
        private MultiPlayerDetailsViewModel vm;

        /// <summary>
        /// Gets a value indicating whether [invoke required].
        /// </summary>
        /// <value><c>true</c> if [invoke required]; otherwise, <c>false</c>.</value>
        public bool InvokeRequired { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerDetails"/> class.
        /// </summary>
        public MultiPlayerDetails()
        {
            InitializeComponent();
            vm = new MultiPlayerDetailsViewModel(new ApplicationMultiPlayerModel());
            DataContext = vm;
            vm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_Maze")
                    Close();
            };
        }

        /// <summary>
        /// Handles the Click event of the btnJoin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            if (GamesList.Items.Count <= 0)
            {
                MessageBox.Show("Games list is empty, please create a new game.");
                return;
            }

            if (GamesList.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a name for the list.");
                return;
            }
            string selectedName = (string) GamesList.SelectedValue;
            vm.Join(selectedName);
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">
        /// rows convert failed.
        /// or
        /// cols convert failed.
        /// </exception>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            string name = MazeDetails.txtBoxName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please insert a name for the maze");
                return;
            }

            string rowsText = MazeDetails.txtBoxRows.Text;
            if (string.IsNullOrEmpty(rowsText))
            {
                MessageBox.Show("Please insert the number of the maze's rows.");
                return;
            }

            string columns = MazeDetails.txtBoxColumns.Text;
            if (string.IsNullOrEmpty(columns))
            {
                MessageBox.Show("Please insert the number of the maze's columns.");
                return;
            }
            if (!int.TryParse(rowsText, out int rows))
            {
                throw new Exception("rows convert failed.");
            }

            if (!int.TryParse(columns, out int cols))
            {
                throw new Exception("cols convert failed.");
            }

            btnStart.Content = "Waiting for a player to join";
            btnStart.IsEnabled = false;
            vm.Start(name, rows, cols);

        }
    }
}
