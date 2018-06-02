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
using System.Windows.Shapes;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interaction logic for WaitAnimation.xaml
    /// </summary>
    public partial class WaitAnimation : Window
    {
        public WaitAnimation()
        {
            InitializeComponent();
        }
        public bool Choose { get; set; }
        public string MessageText { get; private set; }
        public string LeftBtnContent { get; private set; }

        public WaitAnimation(string message, string leftBtnContent)
        {
            text.Text = "Loading";
           // MessageText = message;
            LeftBtnContent = leftBtnContent;
            InitializeComponent();
            DataContext = this;
        }
        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            Choose = false;
            Close();
        }
        
    }
}
