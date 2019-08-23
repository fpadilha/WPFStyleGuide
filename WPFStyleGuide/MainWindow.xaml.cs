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

namespace WPFStyleGuide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }





        private void WinMouseClickEvent(object sender, MouseButtonEventArgs e)
        {
            //TextBox tb = FocusManager.GetFocusedElement(this) as TextBox;

            //if (tb != null && tb.Name != "PART_HexadecimalTextBox")
            //{
            //    Keyboard.ClearFocus();
            //    DependencyObject focusScope = FocusManager.GetFocusScope(this);
            //    FocusManager.SetFocusedElement(focusScope, this);
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FluxInput.GetIsErrorState(tx))
                FluxInput.SetIsErrorState(tx, false);
            else
                FluxInput.SetIsErrorState(tx, true);

        }


    }
}
