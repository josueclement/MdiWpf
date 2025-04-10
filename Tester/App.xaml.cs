using MdiWpf;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System;

namespace Tester;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider? _serviceProvider;
    public IServiceProvider ServiceProvider =>
        _serviceProvider ?? throw new InvalidOperationException("ServiceProvider is not initialized.");

    private void AddDependencyInjection()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<IconsFactory>();
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        AddDependencyInjection();
        
        var window = ServiceProvider.GetRequiredService<MainWindow>();
        window.Show();
    }
}