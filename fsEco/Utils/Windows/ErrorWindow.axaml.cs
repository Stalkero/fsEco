using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace fsEco.Utils.Windows
{
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(string message)
        {
            InitializeComponent();

            var textBlock = this.FindControl<TextBlock>("ErrorMessageText");
            textBlock.Text = message;
        }

        private void OK_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}