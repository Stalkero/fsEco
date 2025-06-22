using Avalonia.Controls;
using CsvHelper;
using fsEco.Classes;
using fsEco.Utils.Windows;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using static fsEco.Utils.Windows.ErrorWindow;


namespace fsEco.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();


        try
        {
            using var reader = new StreamReader("airports.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var airports = csv.GetRecords<fsEco.Classes.airport>().ToList();

            new ErrorWindow($"Airports loaded").Show();
        }
        catch (Exception ex)
        {
            new ErrorWindow($"Error occurred while loading airport csv. {ex.ToString()}").Show();
        }



        MainContent.Content = new MainView();

    }

    public void NavigateTo(UserControl view)
    {
        MainContent.Content = view;
    }
}
