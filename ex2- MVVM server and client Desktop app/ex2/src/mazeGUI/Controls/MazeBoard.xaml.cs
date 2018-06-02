using MazeLib;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.UserControl" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MazeBoard : UserControl
    {
        /// <summary>
        /// The player
        /// </summary>
        private Label player;
        /// <summary>
        /// The goal
        /// </summary>
        private Label goal;

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeBoard"/> class.
        /// </summary>
        public MazeBoard()
        {
            player = new Label();
            goal = new Label();
            OnPlayerImageFilePropertyChanged();
            OnExitImageFilePropertyChanged();
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the goal position.
        /// </summary>
        /// <value>The goal position.</value>
        public Position GoalPos
        {
            get { return (Position)GetValue(GoalPosProperty); }
            set { SetValue(GoalPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GoalPos.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The goal position property
        /// </summary>
        public static readonly DependencyProperty GoalPosProperty =
            DependencyProperty.Register("GoalPos", typeof(Position), typeof(MazeBoard), new PropertyMetadata(new Position(0, 0), OnGoalPosPropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:GoalPosPropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnGoalPosPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnGoalPosPropertyChanged();
        }

        /// <summary>
        /// Called when [goal position property changed].
        /// </summary>
        private void OnGoalPosPropertyChanged()
        {
            double width = myCanvas.Width / Cols;
            double height = myCanvas.Height / Rows;
            goal.Width = width;
            goal.Height = height;
            Canvas.SetLeft(goal, width * GoalPos.Col);
            Canvas.SetTop(goal, height * GoalPos.Row);
            myCanvas.Children.Add(goal);
        }

        /// <summary>
        /// Gets or sets the initial position.
        /// </summary>
        /// <value>The initial position.</value>
        public Position InitialPos
        {
            get { return (Position)GetValue(InitialPosProperty); }
            set { SetValue(InitialPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InitialPos.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The initial position property
        /// </summary>
        public static readonly DependencyProperty InitialPosProperty =
            DependencyProperty.Register("InitialPos", typeof(Position), typeof(MazeBoard), new PropertyMetadata(new Position(0, 0), OnInitialPosPropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:InitialPosPropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnInitialPosPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnInitialPosPropertyChanged();
        }

        /// <summary>
        /// Called when [initial position property changed].
        /// </summary>
        private void OnInitialPosPropertyChanged()
        {
            double width = myCanvas.Width / Cols;
            double height = myCanvas.Height / Rows;
            player.Width = width;
            player.Height = height;
            Canvas.SetLeft(player, width * InitialPos.Col);
            Canvas.SetTop(player, height * InitialPos.Row);
            myCanvas.Children.Add(player);
        }

        /// <summary>
        /// Gets or sets the player position.
        /// </summary>
        /// <value>The player position.</value>
        public Position PlayerPos
        {
            get { return (Position)GetValue(PlayerPosProperty); }
            set { SetValue(PlayerPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerPos.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The player position property
        /// </summary>
        public static readonly DependencyProperty PlayerPosProperty =
            DependencyProperty.Register("PlayerPos", typeof(Position), typeof(MazeBoard), new PropertyMetadata(new Position(0, 0), OnPlayerPosPropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:PlayerPosPropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnPlayerPosPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnPlayerPosPropertyChanged();
        }

        /// <summary>
        /// Called when [player position property changed].
        /// </summary>
        private void OnPlayerPosPropertyChanged()
        {

            double width = myCanvas.Width / Cols;
            double height = myCanvas.Height / Rows;
            //MoveTo(player, new Point(width * p.X, height * p.Y));
            Canvas.SetTop(player, height * PlayerPos.Row);
            Canvas.SetLeft(player, width * PlayerPos.Col);
        }

        /// <summary>
        /// Moves to.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="newP">The new p.</param>
        public void MoveTo(Label target, Point newP)
        {

            Point oldP = new Point()
            {
                X = Canvas.GetLeft(target),
                Y = Canvas.GetTop(target)
            };
            DoubleAnimation anim1 = new DoubleAnimation(oldP.X, newP.X, TimeSpan.FromSeconds(0.20));
            DoubleAnimation anim2 = new DoubleAnimation(oldP.Y, newP.Y, TimeSpan.FromSeconds(0.20));

            target.BeginAnimation(Canvas.LeftProperty, anim1);
            target.BeginAnimation(Canvas.TopProperty, anim2);
            Thread.Sleep(500);
        }

        /// <summary>
        /// Gets or sets the exit image file.
        /// </summary>
        /// <value>The exit image file.</value>
        public string ExitImageFile
        {
            get { return (string)GetValue(ExitImageFileProperty); }
            set { SetValue(ExitImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExitImageFile.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The exit image file property
        /// </summary>
        public static readonly DependencyProperty ExitImageFileProperty =
            DependencyProperty.Register("ExitImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata("exit1.png", OnExitImageFilePropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:ExitImageFilePropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnExitImageFilePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnExitImageFilePropertyChanged();
        }

        /// <summary>
        /// Called when [exit image file property changed].
        /// </summary>
        private void OnExitImageFilePropertyChanged()
        {
            goal.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/" + ExitImageFile)));
        }

        /// <summary>
        /// Gets or sets the player image file.
        /// </summary>
        /// <value>The player image file.</value>
        public string PlayerImageFile
        {
            get { return (string)GetValue(PlayerImageFileProperty); }
            set { SetValue(PlayerImageFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerImageFile.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The player image file property
        /// </summary>
        public static readonly DependencyProperty PlayerImageFileProperty =
            DependencyProperty.Register("PlayerImageFile", typeof(string), typeof(MazeBoard), new PropertyMetadata("simpson.png", OnPlayerImageFilePropertyChanged));

        /// <summary>
        /// Handles the <see cref="E:PlayerImageFilePropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnPlayerImageFilePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnPlayerImageFilePropertyChanged();

        }

        /// <summary>
        /// Called when [player image file property changed].
        /// </summary>
        private void OnPlayerImageFilePropertyChanged()
        {
            player.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Images/" + PlayerImageFile)));
        }

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>The rows.</value>
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The rows property
        /// </summary>
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(int), typeof(MazeBoard), new PropertyMetadata(Properties.Settings.Default.MazeRows));



        /// <summary>
        /// Gets or sets the cols.
        /// </summary>
        /// <value>The cols.</value>
        public int Cols
        {
            get { return (int)GetValue(ColsProperty); }
            set { SetValue(ColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cols.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The cols property
        /// </summary>
        public static readonly DependencyProperty ColsProperty =
            DependencyProperty.Register("Cols", typeof(int), typeof(MazeBoard), new PropertyMetadata(Properties.Settings.Default.MazeCols));



        /// <summary>
        /// Gets or sets the maze.
        /// </summary>
        /// <value>The maze.</value>
        public string Maze
        {
            get { return (string)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>The player.</value>
        public Label Player { get => player; set => player = value; }

        // Using a DependencyProperty as the backing store for MyPropertyMaze.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The maze property
        /// </summary>
        public static readonly DependencyProperty MazeProperty =
            DependencyProperty.Register("Maze", typeof(string), typeof(MazeBoard), new PropertyMetadata("1", OnMazePropertyChanged));


        /// <summary>
        /// Handles the <see cref="E:MazePropertyChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnMazePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MazeBoard board = (MazeBoard)d;
            board.OnMazePropertyChanged();
        }
        /// <summary>
        /// Called when [maze property changed].
        /// </summary>
        private void OnMazePropertyChanged()
        {
            string s = Maze;
            int rows = Rows;
            int cols = Cols;
            double width = myCanvas.Width / cols;
            double height = myCanvas.Height / rows;

            for (int xPos = 0; xPos < cols; xPos++)
            {
                for (int yPos = 0; yPos < rows; yPos++)
                {

                    Label l = new Label();
                    char c = s[xPos + cols * yPos];
                    l.Width = width;
                    l.Height = height;
                    Canvas.SetLeft(l, width * xPos);
                    Canvas.SetTop(l, height * yPos);
                    switch (c)
                    {
                        case '1':
                            l.Background = Brushes.Black;
                            break;

                        case '0':
                            l.Background = Brushes.White;
                            break;

                    }
                    myCanvas.Children.Add(l);
                }
            }
        }
    }
}