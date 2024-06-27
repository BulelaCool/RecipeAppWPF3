using System.Windows;
using System.Windows.Controls;

namespace RecipeAppWPF3
{
    public static class PlaceholderEffect
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached("PlaceholderText", typeof(string), typeof(PlaceholderEffect), new PropertyMetadata(default(string), OnPlaceholderTextChanged));

        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceholderTextProperty);
        }

        public static void SetPlaceholderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceholderTextProperty, value);
        }

        private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.TextChanged -= TextBoxOnTextChanged;
                textBox.GotFocus -= TextBoxOnGotFocus;
                textBox.LostFocus -= TextBoxOnLostFocus;

                if (!string.IsNullOrEmpty((string)e.NewValue))
                {
                    textBox.TextChanged += TextBoxOnTextChanged;
                    textBox.GotFocus += TextBoxOnGotFocus;
                    textBox.LostFocus += TextBoxOnLostFocus;

                    ShowPlaceholder(textBox);
                }
            }
        }

        private static void TextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            ShowPlaceholder((TextBox)sender);
        }

        private static void TextBoxOnGotFocus(object sender, RoutedEventArgs e)
        {
            RemovePlaceholder((TextBox)sender);
        }

        private static void TextBoxOnLostFocus(object sender, RoutedEventArgs e)
        {
            ShowPlaceholder((TextBox)sender);
        }

        private static void ShowPlaceholder(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = GetPlaceholderText(textBox);
                textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        private static void RemovePlaceholder(TextBox textBox)
        {
            if (textBox.Text == GetPlaceholderText(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }
    }
}
