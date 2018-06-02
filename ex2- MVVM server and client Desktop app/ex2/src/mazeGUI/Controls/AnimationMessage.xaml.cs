using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MazeGUI.Controls
{
    /// <summary>
    /// Interaction logic for AnimationMessage.xaml
    /// </summary>
    public partial class AnimationMessage : UserControl
    {
        public AnimationMessage()
        {
            InitializeComponent();
        }

        public string MassageText
        {
            get { return (string)GetValue(MassageTextProperty); }
            set { SetValue(MassageTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QuestionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MassageTextProperty =
            DependencyProperty.Register("MassageText", typeof(string),
                typeof(AnimationMessage), new PropertyMetadata("?", OnMassageTextChanged));

        private static void OnMassageTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AnimationMessage animationMessage)
            {
                animationMessage.OnMassageTextChanged();
            }
        }

        private void OnMassageTextChanged()
        {
            text.Text = MassageText;
        }
        //public string LeftBtnContent
        //{
        //    get { return (string)GetValue(LeftBtnContentProperty); }
        //    set { SetValue(LeftBtnContentProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for LeftBtnContent.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty LeftBtnContentProperty =
        //    DependencyProperty.Register("LeftBtnContent", typeof(string), typeof(AnimationMessage), new PropertyMetadata("?", OnLeftBtnContentChanged));

        //private static void OnLeftBtnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is AnimationMessage animationMessage)
        //    {
        //        animationMessage.OnLeftBtnContentChanged();
        //    }
        //}

        //private void OnLeftBtnContentChanged()
        //{
        //    btnLeft.Content = LeftBtnContent;
        //}
    }
}
