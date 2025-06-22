using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace fsEco.Views;

public partial class JobSearchView : UserControl
{
    public JobSearchView()
    {
        InitializeComponent();
    }

    private void BTN_GoBackToMainMenu(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        if (VisualRoot is MainWindow main)
        {
            main.NavigateTo(new MainView());
        }
    }
}