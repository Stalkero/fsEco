using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CsvHelper;
using fsEco.Classes;
using fsEco.Data;
using fsEco.Economy;
using fsEco.Utils.Windows;
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
        double minDistance = double.Parse(TXT_min_distance_nm.Text);
        double maxDistance = double.Parse(TXT_max_distance_nm.Text);
        double minPay = double.Parse(TXT_min_pay.Text);
        double minCargoWeight = double.Parse(TXT_min_cargo.Text);
        double maxCargoWeight = double.Parse(TXT_max_cargo.Text);

        jobGeneration.generateOneJob(depICAO, minDistance, maxDistance, minPay, minCargoWeight, maxCargoWeight);


        if (JobsDatabase.Jobs != null)
        {
           

            foreach (var job in JobsDatabase.Jobs)
            {
                //Create a StackPanel for each job item


                var JobRow = new Grid();

                JobRow.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
                JobRow.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
                JobRow.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
                JobRow.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
                JobRow.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
                JobRow.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));

                JobRow.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch;

                var JobItemIcao = new TextBlock
                {
                    Text = $"{job.FromIcao} - {job.ToIcao}",
                };
                var JobItemDistance = new TextBlock
                {
                    Text = $"{Math.Round(job.Distance,2)} NM",
                    Margin = new Avalonia.Thickness(10, 0, 10, 0),
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
                };
                var JobItemPay = new TextBlock
                {
                    Text = $"${job.Pay}",
                    Margin = new Avalonia.Thickness(10, 0, 10, 0),
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
                };
                var JobItemCargoWeight = new TextBlock
                {
                    Text = $"{job.CargoWeight} kg",
                    Margin = new Avalonia.Thickness(10, 0, 10, 0),
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
                };

                var JobItemAccept = new Button
                {
                    Content = "Accept",
                    Margin = new Avalonia.Thickness(10, 0, 10, 0),
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    Tag = job

                };

                Grid.SetColumn(JobItemIcao, 0);
                Grid.SetColumn(JobItemDistance, 1);
                Grid.SetColumn(JobItemPay, 2);
                Grid.SetColumn(JobItemCargoWeight, 3);
                Grid.SetColumn(JobItemAccept, 4);

                JobRow.Children.Add(JobItemIcao);
                JobRow.Children.Add(JobItemDistance);
                JobRow.Children.Add(JobItemPay);
                JobRow.Children.Add(JobItemCargoWeight);
                JobRow.Children.Add(JobItemAccept);



                STK_JobList.Children.Add(JobRow);

                JobItemAccept.Click += (sender, args) =>
                {
                    if (sender is Button button && button.Tag is Job selectedJob)
                    {
                       
                        AcceptJob(selectedJob);
                    }
                };

            }
        }
    }

    private void AcceptJob(Job job)
    {
       
        new ErrorWindow($"Accepted job: {job.FromIcao} -> {job.ToIcao}, Distance: {job.Distance}").Show();
    }

}