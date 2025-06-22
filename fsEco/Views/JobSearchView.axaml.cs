using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CsvHelper;
using fsEco.Data;
using fsEco.Economy;
using System;
using System.Linq;

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

    private void BTN_SearchJob_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        JobsDatabase.Jobs.Clear();
        STK_JobList.Children.Clear();
        

        JobGeneration jobGeneration = new JobGeneration();

        string depICAO = TXT_Departure_ICAO.Text;
        string arrICAO = TXT_Arrival_ICAO.Text;
        double minDistance = double.Parse(TXT_min_distance_nm.Text);
        double maxDistance = double.Parse(TXT_max_distance_nm.Text);
        double minPay = double.Parse(TXT_min_pay.Text);
        double minCargoWeight = double.Parse(TXT_min_cargo.Text);
        double maxCargoWeight = double.Parse(TXT_max_cargo.Text);

        jobGeneration.generateOneJob(depICAO, arrICAO, minDistance, maxDistance, minPay, minCargoWeight, maxCargoWeight);


        if (JobsDatabase.Jobs != null)
        {
           

            foreach (var job in JobsDatabase.Jobs)
            {
                //Create a StackPanel for each job item

                var JobItemPanel = new StackPanel
                {
                    Orientation = Avalonia.Layout.Orientation.Horizontal,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                };



                var JobItemIcao = new TextBlock
                {
                    Text = $"{job.FromIcao} - {job.ToIcao}",
                };
                var JobItemDistance = new TextBlock
                {
                    Text = $"Distance: {Math.Round(job.Distance,2)} NM",
                    Margin = new Avalonia.Thickness(10, 0, 0, 0),
                };
                var JobItemPay = new TextBlock
                {
                    Text = $"Pay: ${job.Pay}",
                    Margin = new Avalonia.Thickness(10, 0, 0, 0),
                };
                var JobItemCargoWeight = new TextBlock
                {
                    Text = $"Cargo Weight: {job.CargoWeight} kg",
                    Margin = new Avalonia.Thickness(10, 0, 0, 0),
                };

                Grid.SetColumn(JobItemIcao, 0);
                Grid.SetColumn(JobItemDistance, 1);
                Grid.SetColumn(JobItemPay, 2);
                Grid.SetColumn(JobItemCargoWeight, 3);

                JobItemPanel.Children.Add(JobItemIcao);
                JobItemPanel.Children.Add(JobItemDistance);
                JobItemPanel.Children.Add(JobItemPay);
                JobItemPanel.Children.Add(JobItemCargoWeight);



                STK_JobList.Children.Add(JobItemPanel);
            }
        }
    }
}