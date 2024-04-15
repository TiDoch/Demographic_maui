using MardocheDespagne_MAUI_demo.Services;
using MardocheDespagne_MAUI_demo.ViewModels;
using MardocheDespagne_MAUI_demo.Views;

namespace MardocheDespagne_MAUI_demo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<IPersonneService, PersonneService>();


        //Views Registration
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<AjouterPersonne>();


        //View Modles 
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<AjouterPersonneViewModel>();


        return builder.Build();
    }
}
