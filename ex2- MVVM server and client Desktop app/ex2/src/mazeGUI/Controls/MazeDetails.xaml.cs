using System;
using System.Windows;
using System.Windows.Controls;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for MazeDetails.xaml
    /// </summary>
    public partial class MazeDetails : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MazeDetails"/> class.
        /// </summary>
        public MazeDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the IsKeyboardFocusedChanged event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void TextBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    tb.Clear();
                }
            }
        }




        /// <summary>
        /// Gets or sets the default maze cols.
        /// </summary>
        /// <value>The default maze cols.</value>
        public int DefaultMazeCols
        {
            get { return (int)GetValue(DefaultMazeColsProperty); }
            set { SetValue(DefaultMazeColsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultMazeCols.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The default maze cols property
        /// </summary>
        public static readonly DependencyProperty DefaultMazeColsProperty =
            DependencyProperty.Register("DefaultMazeCols", typeof(int), typeof(MazeDetails), new PropertyMetadata(0, OnDefaultMazeColsChanged));

        /// <summary>
        /// Handles the <see cref="E:DefaultMazeColsChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDefaultMazeColsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MazeDetails mazeDetails)
            {
                mazeDetails.OnDefaultMazeColsChanged();
            }
        }

        /// <summary>
        /// Called when [default maze cols changed].
        /// </summary>
        private void OnDefaultMazeColsChanged()
        {
            txtBoxColumns.Text = DefaultMazeCols.ToString();
        }

        /// <summary>
        /// Gets or sets the default maze rows.
        /// </summary>
        /// <value>The default maze rows.</value>
        public int DefaultMazeRows
        {
            get { return (int)GetValue(DefaultMazeRowsProperty); }
            set { SetValue(DefaultMazeRowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The default maze rows property
        /// </summary>
        public static readonly DependencyProperty DefaultMazeRowsProperty =
            DependencyProperty.Register("DefaultMazeRows", typeof(int), typeof(MazeDetails), new PropertyMetadata(0, OnDefaultMazeRowsChanged));

        /// <summary>
        /// Handles the <see cref="E:DefaultMazeRowsChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnDefaultMazeRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MazeDetails mazeDetails)
            {
                mazeDetails.OnDefaultMazeRowsChanged();
            }
        }

        /// <summary>
        /// Called when [default maze rows changed].
        /// </summary>
        private void OnDefaultMazeRowsChanged()
        {
            txtBoxRows.Text = DefaultMazeRows.ToString();
        }
    }
}
