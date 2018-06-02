using System.Windows;
using System.Windows.Controls;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for PopQuestion.xaml
    /// </summary>
    public partial class PopQuestion : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PopQuestion"/> class.
        /// </summary>
        public PopQuestion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the content of the left BTN.
        /// </summary>
        /// <value>The content of the left BTN.</value>
        public string LeftBtnContent
        {
            get { return (string)GetValue(LeftBtnContentProperty); }
            set { SetValue(LeftBtnContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LeftBtnContent.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The left BTN content property
        /// </summary>
        public static readonly DependencyProperty LeftBtnContentProperty =
            DependencyProperty.Register("LeftBtnContent", typeof(string), typeof(PopQuestion), new PropertyMetadata("?", OnLeftBtnContentChanged));

        /// <summary>
        /// Gets or sets the content of the right BTN.
        /// </summary>
        /// <value>The content of the right BTN.</value>
        public string RightBtnContent
        {
            get { return (string)GetValue(RightBtnContentProperty); }
            set { SetValue(RightBtnContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LeftBtnContent.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The right BTN content property
        /// </summary>
        public static readonly DependencyProperty RightBtnContentProperty =
            DependencyProperty.Register("RightBtnContent", typeof(string), typeof(PopQuestion), new PropertyMetadata("?", OnRightBtnContentChanged));



        /// <summary>
        /// Gets or sets the massage text.
        /// </summary>
        /// <value>The massage text.</value>
        public string MassageText
        {
            get { return (string)GetValue(MassageTextProperty); }
            set { SetValue(MassageTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QuestionText.  This enables animation, styling, binding, etc...
        /// <summary>
        /// The massage text property
        /// </summary>
        public static readonly DependencyProperty MassageTextProperty =
            DependencyProperty.Register("MassageText", typeof(string), typeof(PopQuestion), new PropertyMetadata("?", OnMassageTextChanged));

        /// <summary>
        /// Handles the <see cref="E:MassageTextChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnMassageTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PopQuestion popQuestion)
            {
                popQuestion.OnMassageTextChanged();
            }
        }

        /// <summary>
        /// Called when [massage text changed].
        /// </summary>
        private void OnMassageTextChanged()
        {
            text.Text = MassageText;
        }

        /// <summary>
        /// Handles the <see cref="E:RightBtnContentChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnRightBtnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PopQuestion popQuestion)
            {
                popQuestion.OnRightBtnContentChanged();
            }
        }

        /// <summary>
        /// Called when [right BTN content changed].
        /// </summary>
        private void OnRightBtnContentChanged()
        {
            btnRight.Content = RightBtnContent;
        }

        /// <summary>
        /// Handles the <see cref="E:LeftBtnContentChanged" /> event.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnLeftBtnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PopQuestion popQuestion)
            {
                popQuestion.OnLeftBtnContentChanged();
            }
        }

        /// <summary>
        /// Called when [left BTN content changed].
        /// </summary>
        private void OnLeftBtnContentChanged()
        {
            btnLeft.Content = LeftBtnContent;
        }
    }
}
