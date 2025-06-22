using Avalonia.Controls;
using CsvHelper;
using fsEco.Classes;
using fsEco.Utils.Windows;
using System.Globalization;
using System.IO;
using System.Linq;

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
