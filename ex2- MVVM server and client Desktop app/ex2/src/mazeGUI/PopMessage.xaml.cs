using System.Windows;

namespace MazeGUI
{
    /// <summary>
    /// Interaction logic for AskToSolve.xaml
    /// </summary>
    public partial class PopMessage : Window
    {  /// <summary>
       /// this is the pop up maessage
       /// </summary>
       /// <summary>
       /// Gets what is the choise
       /// </summary>
       /// <value>The content of the right BTN.</value>
        public bool Choose { get; set; }
        /// <summary>
        /// Gets the content of the right BTN.
        /// </summary>
        /// <value>The content of the right BTN.</value>
        public string RightBtnContent { get; private set; }
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; private set; }
        /// <summary>
        /// Gets the content of the left BTN.
        /// </summary>
        /// <value>The content of the left BTN.</value>
        public string LeftBtnContent { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PopMessage"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="leftBtnContent">Content of the left BTN.</param>
        /// <param name="rightBtnContent">Content of the right BTN.</param>
        public PopMessage(string message, string leftBtnContent, string rightBtnContent)
        {
            Message = message;
            LeftBtnContent = leftBtnContent;
            RightBtnContent = rightBtnContent;
            InitializeComponent();
            DataContext = this;
            ucPopQuestion.btnLeft.Click += BtnLeft_Click;
            ucPopQuestion.btnRight.Click += BtnRight_Click;
        }
        /// <summary>
        /// Handles the Click event of the BtnLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            Choose = false;
            Close();
        }
        /// <summary>
        /// Handles the Click event of the BtnRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            Choose = true;
            Close();
        }


    }
}
