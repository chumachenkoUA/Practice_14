using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace Practice_14;

public partial class MainWindow : Window
{
    private Bus? mainBus;
    private Bus? currentBus;

    public MainWindow()
    {
        InitializeComponent();

        CreateBusBtn.Click += CreateBusBtn_Click;
        CreateExpressBtn.Click += CreateExpressBtn_Click;
        CreateSuburbanBtn.Click += CreateSuburbanBtn_Click;
        CreateCityBtn.Click += CreateCityBtn_Click;
        DepartBtn.Click += DepartBtn_Click;
        ServiceBtn.Click += ServiceBtn_Click;
        DriveBtn.Click += DriveBtn_Click;
    }

    private void CreateBusBtn_Click(object? sender, RoutedEventArgs e)
    {
        mainBus = new Bus("Автобус");
        currentBus = mainBus;
        InfoText.Text = $"Створено: {mainBus.GetInfo()}";
        currentBus.OnDeparted += Bus_OnDeparted;
        CreateExpressBtn.IsEnabled = true;
        CreateSuburbanBtn.IsEnabled = true;
        CreateCityBtn.IsEnabled = true;
        DepartBtn.IsEnabled = true;
        ServiceBtn.IsEnabled = true;
        DriveBtn.IsEnabled = true;
    }

    private void CreateExpressBtn_Click(object? sender, RoutedEventArgs e)
    {
        currentBus = new ExpressBus("Експрес");
        currentBus.OnDeparted += Bus_OnDeparted;
        InfoText.Text = $"Створено: {currentBus.GetInfo()}";
    }

    private void CreateSuburbanBtn_Click(object? sender, RoutedEventArgs e)
    {
        currentBus = new SuburbanBus("Приміський");
        currentBus.OnDeparted += Bus_OnDeparted;
        InfoText.Text = $"Створено: {currentBus.GetInfo()}";
    }

    private void CreateCityBtn_Click(object? sender, RoutedEventArgs e)
    {
        currentBus = new CityBus("Міський");
        currentBus.OnDeparted += Bus_OnDeparted;
        InfoText.Text = $"Створено: {currentBus.GetInfo()}";
    }

    private void DepartBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (currentBus != null)
        {
            currentBus.Depart();
        }
    }

    private void ServiceBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (currentBus != null)
        {
            InfoText.Text = currentBus.Service();
        }
    }

    private void DriveBtn_Click(object? sender, RoutedEventArgs e)
    {
        if (currentBus != null)
        {
            InfoText.Text = currentBus.Drive();
        }
    }

    private void Bus_OnDeparted(object? sender, EventArgs e)
    {
        InfoText.Text = $"{currentBus?.Name} відправився!";
    }
}
