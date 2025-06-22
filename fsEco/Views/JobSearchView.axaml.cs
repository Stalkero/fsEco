using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CsvHelper;
using fsEco.Classes;
using fsEco.PublicData;
using fsEco.Economy.JobGeneration;
using fsEco.Utils.Windows;
using System;
using System.Linq;
using Avalonia.Media;

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


                var JobRow = new StackPanel();
                JobRow.Orientation = Avalonia.Layout.Orientation.Horizontal;    
                JobRow.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;

                var JobItemIcao = new TextBlock
                {
                    Text = $"{job.FromIcao} - {job.ToIcao}",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Width = 200
                };
                var JobItemDistance = new TextBlock
                {
                    Text = $"{Math.Round(job.Distance,2)}",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Width = 200
                };
                var JobItemPay = new TextBlock
                {
                    Text = $"${job.Pay}",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Width = 200
                };

                var JobItemCargoType = new TextBlock
                {
                    Text = $"{job.cargoType}",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Width = 200
                };

                var JobItemCargoWeight = new TextBlock
                {
                    Text = $"{job.CargoWeight} kg",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Width = 200
                };

                var JobItemDescription = new TextBlock
                {
                    Text = job.Description ?? "No description",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    Width = 200
                };

                var JobItemAccept = new Button
                {
                    Content = "Accept",
                    HorizontalContentAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    Tag = job,
                    Width = 200
                };

                JobRow.Children.Add(JobItemIcao);
                JobRow.Children.Add(JobItemDistance);
                JobRow.Children.Add(JobItemPay);
                JobRow.Children.Add(JobItemCargoType);
                JobRow.Children.Add(JobItemCargoWeight);
                JobRow.Children.Add(JobItemDescription);
                JobRow.Children.Add(JobItemAccept);



                STK_JobList.Children.Add(JobRow);

                JobItemAccept.Click += (sender, args) =>
                {
                    if (sender is Button button && button.Tag is JobListing selectedJob)
                    {
                       
                        AcceptJob(selectedJob);
                    }
                };

            }
        }
    }

    private void AcceptJob(JobListing job)
    {
       
        new ErrorWindow($"Accepted job: {job.FromIcao} -> {job.ToIcao}, Distance: {job.Distance}").Show();
    }

}