using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Fluxonaut.UI.Components
{

    public class UIInputs : DependencyObject
    { 
        #region Attached Properties

        public static bool GetIsSearch(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSearchProperty);
        }

        public static void SetIsSearch(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSearchProperty, value);
        }

        public static readonly DependencyProperty IsSearchProperty =
            DependencyProperty.RegisterAttached("IsSearch", typeof(bool), typeof(UIInputs), new UIPropertyMetadata(false));



        public static bool GetHasClearButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasClearButtonProperty);
        }

        public static void SetHasClearButton(DependencyObject obj, bool value)
        {
            obj.SetValue(HasClearButtonProperty, value);
        }

        public static readonly DependencyProperty HasClearButtonProperty =
            DependencyProperty.RegisterAttached("HasClearButton", typeof(bool), typeof(UIInputs), new UIPropertyMetadata(false));



        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(UIInputs), new UIPropertyMetadata(false, OnIsMonitoringChanged));



        public static string GetWatermarkText(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkTextProperty);
        }

        public static void SetWatermarkText(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkTextProperty, value);
        }

        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.RegisterAttached("WatermarkText", typeof(string), typeof(UIInputs), new UIPropertyMetadata(string.Empty));



        public static int GetTextLength(DependencyObject obj)
        {
            return (int)obj.GetValue(TextLengthProperty);
        }

        public static void SetTextLength(DependencyObject obj, int value, bool isFocused)
        {
            obj.SetValue(TextLengthProperty, value);

            if (value >= 1)
            {
                obj.SetValue(HasTextProperty, true);
                obj.SetValue(IsEmptyAndUnfocusedProperty, false);

            }
            else
            {
                obj.SetValue(HasTextProperty, false);
                if (isFocused)
                    obj.SetValue(IsEmptyAndUnfocusedProperty, false);
                else
                    obj.SetValue(IsEmptyAndUnfocusedProperty, true);
            }
        }

        public static readonly DependencyProperty TextLengthProperty =
            DependencyProperty.RegisterAttached("TextLength", typeof(int), typeof(UIInputs), new UIPropertyMetadata(0));



        public static double GetWatermarkFontSize(DependencyObject obj)
        {
            return (double)obj.GetValue(WatermarkFontSizeProperty);
        }

        public static void SetWatermarkFontSize(DependencyObject obj, double value)
        {
            obj.SetValue(WatermarkFontSizeProperty, value);
        }

        public static readonly DependencyProperty WatermarkFontSizeProperty =
            DependencyProperty.RegisterAttached("WatermarkFontSize", typeof(double), typeof(UIInputs), new UIPropertyMetadata(double.NaN));



        public static bool GetIsErrorState(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsErrorStateProperty);
        }

        public static void SetIsErrorState(DependencyObject obj, bool value)
        {
            obj.SetValue(IsErrorStateProperty, value);
        }

        public static readonly DependencyProperty IsErrorStateProperty =
            DependencyProperty.RegisterAttached("IsErrorState", typeof(bool), typeof(UIInputs), new UIPropertyMetadata(false));




        #endregion

        #region Internal DependencyProperty

        public bool IsEmptyAndUnfocused
        {
            get { return (bool)GetValue(IsEmptyAndUnfocusedProperty); }
            set { SetValue(IsEmptyAndUnfocusedProperty, value); }
        }

        private static readonly DependencyProperty IsEmptyAndUnfocusedProperty =
            DependencyProperty.RegisterAttached("IsEmptyAndUnfocused", typeof(bool), typeof(UIInputs), new FrameworkPropertyMetadata(true));


        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            set { SetValue(HasTextProperty, value); }
        }

        private static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(UIInputs), new FrameworkPropertyMetadata(false));


        #endregion

        #region Implementation

        static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox)
            {
                TextBox txtBox = d as TextBox;

                if ((bool)e.NewValue)
                {
                    try
                    {
                        Window win = Window.GetWindow(txtBox);
                        win.PreviewMouseLeftButtonDown += Win_PreviewMouseLeftButtonDown;
                        win.PreviewKeyDown += Win_PreviewKeyDown;
                        win.Closing += Win_ForcedDispose;
                    }
                    catch { }

                    txtBox.TextChanged += TextChanged;
                    txtBox.GotFocus += TextFocusChanged;
                    txtBox.LostFocus += TextFocusChanged;
                }
                else
                {
                    try
                    {
                        Window win = Window.GetWindow(txtBox);
                        win.PreviewMouseLeftButtonDown -= Win_PreviewMouseLeftButtonDown;
                        win.PreviewKeyDown -= Win_PreviewKeyDown;
                        win.Closing -= Win_ForcedDispose;
                    }
                    catch { }
                    txtBox.TextChanged -= TextChanged;
                    txtBox.GotFocus -= TextFocusChanged;
                    txtBox.LostFocus -= TextFocusChanged;
                }
            }
            else if (d is PasswordBox)
            {
                PasswordBox passBox = d as PasswordBox;

                if ((bool)e.NewValue)
                {
                    try
                    {
                        Window win = Window.GetWindow(passBox);
                        win.PreviewMouseLeftButtonDown += Win_PreviewMouseLeftButtonDown;
                        win.PreviewKeyDown += Win_PreviewKeyDown;
                    }
                    catch { }
                    passBox.PasswordChanged += PasswordFocusChanged;
                    passBox.GotFocus += PasswordFocusChanged;
                    passBox.LostFocus += PasswordFocusChanged;
                }
                else
                {
                    try
                    {
                        Window win = Window.GetWindow(passBox);
                        win.PreviewMouseLeftButtonDown -= Win_PreviewMouseLeftButtonDown;
                        win.PreviewKeyDown -= Win_PreviewKeyDown;
                    }
                    catch { }
                    passBox.PasswordChanged -= PasswordFocusChanged;
                    passBox.GotFocus -= PasswordFocusChanged;
                    passBox.LostFocus -= PasswordFocusChanged;
                }
            }
        }


        private static void Win_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Window win = sender as Window;
                if (win != null)
                {
                    TextBox tb = FocusManager.GetFocusedElement(win) as TextBox;

                    if (tb != null && tb.Text.Length == 0 && tb.Name != "PART_HexadecimalTextBox")
                        ClearFocus(win);
                }
            }
        }

        private static void Win_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window win = sender as Window;
            TextBox tb = FocusManager.GetFocusedElement(win) as TextBox;

            if (win != null && tb != null && tb.Name != "PART_HexadecimalTextBox")
                ClearFocus(win);
        }

        private static void Win_ForcedDispose(object sender, CancelEventArgs e)
        {
            Window win = sender as Window;
            if (win != null)
            {
                try { win.PreviewKeyDown -= Win_PreviewKeyDown; } catch { }
                try { win.PreviewMouseLeftButtonDown -= Win_PreviewMouseLeftButtonDown; } catch { }
                try { win.Closing -= Win_ForcedDispose; } catch { }
            }
        }

        private static void ClearFocus(Window win)
        {
            Keyboard.ClearFocus();
            DependencyObject focusScope = FocusManager.GetFocusScope(win);
            FocusManager.SetFocusedElement(focusScope, win);
        }

        public static void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox == null) return;
            SetTextLength(txtBox, txtBox.Text.Length, txtBox.IsFocused);
        }

        static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passBox = sender as PasswordBox;
            if (passBox == null) return;
            SetTextLength(passBox, passBox.Password.Length, passBox.IsFocused);
        }
        static void TextFocusChanged(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox == null) return;
            SetTextLength(txtBox, txtBox.Text.Length, txtBox.IsFocused);
        }

        static void PasswordFocusChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passBox = sender as PasswordBox;
            if (passBox == null) return;
            SetTextLength(passBox, passBox.Password.Length, passBox.IsFocused);
        }


        #endregion
    }

    public partial class UIInputsHandlers : ResourceDictionary
    {
      
  
    }
}
