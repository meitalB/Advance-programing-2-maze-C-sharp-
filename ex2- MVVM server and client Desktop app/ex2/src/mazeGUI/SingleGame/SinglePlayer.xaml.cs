using ClientLib;
using System.Windows;
using System.Configuration;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System;
using System.Windows.Threading;
using MazeLib;
using System.Windows.Data;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interaction logic for SinglePlayer.xaml
    /// </summary>
    public partial class SinglePlayer : Window
    {
        /// <summary>
        /// The vm
        /// </summary>
        private SinglePlayerViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglePlayer"/> class.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        public SinglePlayer(string mazeName, int rows, int cols)
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel(new ApplicationSinglePlayerModel(mazeName, rows, cols));
            DataContext = vm;
            SetBinding(YouWonProperty, new Binding("YouWon"));
        }



        /// <summary>
        /// Gets or sets a value indicating whether [you won].
        /// </summary>
        /// <value><c>true</c> if [you won]; otherwise, <c>false</c>.</value>
        public bool YouWon
        {
            get { return (bool)GetValue(YouWonProperty); }
            set { SetValue(YouWonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YouWon.  This enables animation, styling, binding, etc...
        /// <summary>
        /// You won property
        /// </summary>
        public static readonly DependencyProperty YouWonProperty =
            DependencyProperty.Register("YouWon", typeof(bool), typeof(SinglePlayer), new PropertyMetadata(false, OnYouWonPropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:YouWonPropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnYouWonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SinglePlayer win = (SinglePlayer)d;
            win.OnYouWonPropertyChanged();
        }

        /// <summary>
        /// Called when [you won property changed].
        /// </summary>
        private void OnYouWonPropertyChanged()
        {
            if (YouWon == true)
            {
                PopMessage youWonMessage = new PopMessage("You Won", "Keep playing", "Return to main menu");
                if (youWonMessage.ShowDialog() != true)
                {
                    if (youWonMessage.Choose == true) //solve the game
                    {
                        BackToMainMenu();
                    }
                }
            }
            YouWon = false;
        }

        /// <summary>
        /// Handles the Click event of the btnReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            PopMessage resetMessage = new PopMessage("Do you want to reset this maze?", "No", "Yes");
            if (resetMessage.ShowDialog() != true)
            {
                if (resetMessage.Choose == true) //reset the game
                {
                    vm.Reset();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSolve control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            PopMessage solveMessage = new PopMessage("Do you want to solve this maze?", "No", "Yes");
            if (solveMessage.ShowDialog() != true)
            {
                if (solveMessage.Choose == true) //solve the game
                {
                    vm.Solve();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            BackToMainMenu();
        }

        /// <summary>
        /// Backs to main menu.
        /// </summary>
        private void BackToMainMenu()
        {
            MainWindow win = new MainWindow()
            {
                Top = Top,
                Left = Left
            };
            win.Show();
            Close();
        }

        /// <summary>
        /// Handles the KeyDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    vm.MovePlayer(Direction.Up);
                    break;

                case Key.Down:
                    vm.MovePlayer(Direction.Down);
                    break;

                case Key.Right:
                    vm.MovePlayer(Direction.Right);
                    break;

                case Key.Left:
                    vm.MovePlayer(Direction.Left);
                    break;
            }
        }
    }
}