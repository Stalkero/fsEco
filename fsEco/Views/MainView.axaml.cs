using Avalonia.Controls;
using Microsoft.VisualBasic;
using System.Windows;

namespace fsEco.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void BTN_JobSearch_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow main)
        {
            main.NavigateTo( new JobSearchView());
        }
    }
}
