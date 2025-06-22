using Avalonia.Controls;

namespace fsEco.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MainContent.Content = new MainView();
    }

    public void NavigateTo(UserControl view)
    {
        MainContent.Content = view;
    }
}
