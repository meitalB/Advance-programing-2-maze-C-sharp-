using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for MultiPlayer.xaml
    /// </summary>
    public partial class MultiPlayer : Window
    {
        /// <summary>
        /// The vm
        /// </summary>
        private MultiPlayerViewModel vm;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayer"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MultiPlayer(IMultiPlayerModel model)
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel(model);
            DataContext = vm;
            SetBinding(YouWonProperty, new Binding("YouWon"));
            SetBinding(OpponentWonProperty, new Binding("OpponentWon"));
            SetBinding(ExitGameProperty, new Binding("ExitGame"));
            SetBinding(LostConnectionProperty, new Binding("LostConnection"));
        }



        /// <summary>
        /// Gets or sets a value indicating whether [lost connection].
        /// </summary>
        /// <value><c>true</c> if [lost connection]; otherwise, <c>false</c>.</value>
        public bool LostConnection
        {
            get { return (bool)GetValue(LostConnectionProperty); }
            set { SetValue(LostConnectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LostConnection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LostConnectionProperty =
            DependencyProperty.Register("LostConnection", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnLostConnectionPropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:LostConnectionPropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnLostConnectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnLostConnectionPropertyChanged();
        }

        /// <summary>
        /// Called when [lost connection property changed].
        /// </summary>
        private void OnLostConnectionPropertyChanged()
        {
            if (LostConnection == true)
            {
                MessageBox.Show("Lost Connection");

            }
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }


        /// <summary>
        /// Gets or sets a value indicating whether [exit game].
        /// </summary>
        /// <value><c>true</c> if [exit game]; otherwise, <c>false</c>.</value>
        public bool ExitGame
        {
            get { return (bool)GetValue(ExitGameProperty); }
            set { SetValue(ExitGameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExitGame.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExitGameProperty =
            DependencyProperty.Register("ExitGame", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnExitGamePropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:ExitGamePropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnExitGamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnExitGamePropertyChanged();
        }

        /// <summary>
        /// Called when [exit game property changed].
        /// </summary>
        private void OnExitGamePropertyChanged()
        {
            if (ExitGame == true)
            {
                MessageBox.Show("Opponent close the game.");
            }
            MainWindow win = new MainWindow();
            win.Show();
            Close();
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
        public static readonly DependencyProperty YouWonProperty =
            DependencyProperty.Register("YouWonMultiPlayer", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnYouWonPropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:YouWonPropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnYouWonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnYouWonPropertyChanged();
        }

        /// <summary>
        /// Called when [you won property changed].
        /// </summary>
        private void OnYouWonPropertyChanged()
        {
            if (YouWon == true)
            {
                MessageBox.Show("You Won");
                //PopMessage youWonMessage = new PopMessage("You Won", "Keep playing", "");
                //if (youWonMessage.ShowDialog() != true)
                //{
                   
                //}
            }
            YouWon = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [opponent won].
        /// </summary>
        /// <value><c>true</c> if [opponent won]; otherwise, <c>false</c>.</value>
        public bool OpponentWon
        {
            get { return (bool)GetValue(OpponentWonProperty); }
            set { SetValue(OpponentWonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YouWon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpponentWonProperty =
            DependencyProperty.Register("YouWon", typeof(bool), typeof(MultiPlayer), new PropertyMetadata(false, OnOpponentWonPropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:OpponentWonPropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnOpponentWonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiPlayer win = (MultiPlayer)d;
            win.OnOpponentWonPropertyChanged();
        }

        /// <summary>
        /// Called when [opponent won property changed].
        /// </summary>
        private void OnOpponentWonPropertyChanged()
        {
            if (OpponentWon == true)
            {
                MessageBox.Show("You Lose");

                //PopMessage youWonMessage = new PopMessage("You Lose!!!", "Keep playing", "");
                //if (youWonMessage.ShowDialog() != true)
                //{

                //}
            }
            OpponentWon = false;
        }


        /// <summary>
        /// Handles the Click event of the btnMainMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            PopMessage exitMessage = new PopMessage("Do you want to exit this maze?", "No", "Yes");
            if (exitMessage.ShowDialog() != true)
            {
                if (exitMessage.Choose == true) //exit the game
                {
                    BackToMainMenu();
                }
            }
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

        /// <summary>
        /// Backs to main menu.
        /// </summary>
        private void BackToMainMenu()
        {
            vm.Close();
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }

        /// <summary>
        /// Closes the win.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeWin(object sender, EventArgs e)
        {
            vm.Close();
        }
    }
}
