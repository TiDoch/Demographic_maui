using MardocheDespagne_MAUI_demo.Views;

namespace MardocheDespagne_MAUI_demo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AjouterPersonne), typeof(AjouterPersonne));
    }
}
